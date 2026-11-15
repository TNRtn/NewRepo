IF OBJECT_ID('dbo.spGetCategories', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetCategories;
END
GO

CREATE PROCEDURE dbo.spGetCategories
(
    @Id INT = NULL,
    @Name NVARCHAR(150) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @sql NVARCHAR(MAX) = '';

    SET @sql = @sql + ' SELECT ';
    SET @sql = @sql + ' ID, ';
    SET @sql = @sql + ' Name ';
    SET @sql = @sql + ' FROM dbo.Category ';
    SET @sql = @sql + ' WHERE 1 = 1 ';
    SET @sql = @sql + ' AND IsActive = 1 ';

    -- Filter by ID
    IF (@Id IS NOT NULL)
    BEGIN
        SET @sql = @sql + ' AND ID = @Id ';
    END

    -- Filter by Name
    IF (NULLIF(TRIM(@Name), '') IS NOT NULL)
    BEGIN
        SET @sql = @sql + ' AND Name LIKE ''%'' + @Name + ''%'' ';
    END

    EXEC sp_executesql
        @sql,
        N'@Id INT, @Name NVARCHAR(150)',
        @Id = @Id,
        @Name = @Name;

END
GO