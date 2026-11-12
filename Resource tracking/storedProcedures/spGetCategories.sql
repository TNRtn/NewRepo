IF OBJECT_ID('dbo.spGetCategories', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetCategories;
END
GO

CREATE PROCEDURE dbo.spGetCategories
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ID,
        Name
    FROM dbo.Category
    WHERE IsActive = 1;
END
GO