IF OBJECT_ID('dbo.spGetResoureces', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetResoureces;
END
GO

CREATE PROCEDURE dbo.spGetResoureces
    @Id INT = NULL,
    @Name NVARCHAR(200) = NULL,
    @CategoryId INT = NULL,
	@RevisionCount INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = '
        SELECT
            R.Id,
            R.Name,
            R.Description,
            R.CategoryId,
            C.Name AS CategoryName,
            R.IsActive,
            R.ReferenceKeys,
            R.ReferenceNoteLinks,
            R.KeyPoints,
            R.RevisionCount
        FROM dbo.Resources R
        INNER JOIN dbo.Category C
            ON R.CategoryId = C.Id
        WHERE R.IsActive = 1
          AND C.IsActive = 1
    ';

    IF @Id IS NOT NULL
        SET @SQL = @SQL + ' AND R.Id = @Id';

    IF @Name IS NOT NULL AND @Name <> ''
        SET @SQL = @SQL + ' AND R.Name LIKE ''%'' + @Name + ''%''';

    IF @CategoryId IS NOT NULL
        SET @SQL = @SQL + ' AND R.CategoryId = @CategoryId';
	IF @RevisionCount IS NOT NULL
		SET @SQL = @SQL +' AND R.RevisionCount = @RevisionCount '

    SET @SQL = @SQL + ' ORDER BY R.Id DESC';

    EXEC sp_executesql
        @SQL,
        N'@Id INT, @Name NVARCHAR(200), @CategoryId INT, @RevisionCount INT',
        @Id = @Id,
        @Name = @Name,
        @CategoryId = @CategoryId,
		@RevisionCount = @RevisionCount
		;
END
GO