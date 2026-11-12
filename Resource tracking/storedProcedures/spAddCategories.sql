IF OBJECT_ID('dbo.spAddCategories', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spAddCategories;
END
GO

CREATE PROCEDURE dbo.spAddCategories
(
	@Name NVARCHAR(250)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Category
	VALUES(@Name,1);
END
GO