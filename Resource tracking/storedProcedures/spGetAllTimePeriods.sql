IF OBJECT_ID('dbo.spGetAllTimePeriods', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetAllTimePeriods;
END
GO

CREATE PROCEDURE dbo.spGetAllTimePeriods
(
    @Id INT = NULL,
    @CategoryId INT = NULL,
    @SearchName NVARCHAR(200) = NULL,
    @SortOrder NVARCHAR(4) = 'DESC'
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validate sorting order
    IF UPPER(@SortOrder) NOT IN ('ASC', 'DESC')
    BEGIN
        SET @SortOrder = 'DESC';
    END

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = '
        SELECT
            T.Id,
            T.Name,
            T.PeriodDate,
            T.Description,
            T.CategoryId,
            C.Name AS CategoryName,
            T.KeyNotes,
            T.KeyReferenceLinks
        FROM dbo.TimePeriods T
        INNER JOIN dbo.Category C
            ON T.CategoryId = C.Id
        WHERE T.IsActive = 1
    ';

    -- Filter by TimePeriod ID
    IF @Id IS NOT NULL
    BEGIN
        SET @SQL = @SQL + ' AND T.Id = @Id';
    END

    -- Filter by Category ID
    IF @CategoryId IS NOT NULL
    BEGIN
        SET @SQL = @SQL + ' AND T.CategoryId = @CategoryId';
    END

    -- Search by Name
    IF @SearchName IS NOT NULL AND LTRIM(RTRIM(@SearchName)) <> ''
    BEGIN
        SET @SQL = @SQL + ' AND T.Name LIKE ''%'' + @SearchName + ''%''';
    END

    -- Sort by PeriodDate
    SET @SQL = @SQL + ' ORDER BY T.PeriodDate ' + UPPER(@SortOrder)
                    + ', T.Id DESC';

    -- Execute dynamic SQL safely using parameters
    EXEC sp_executesql
        @SQL,
        N'@Id INT, @CategoryId INT, @SearchName NVARCHAR(200)',
        @Id = @Id,
        @CategoryId = @CategoryId,
        @SearchName = @SearchName;

END
GO