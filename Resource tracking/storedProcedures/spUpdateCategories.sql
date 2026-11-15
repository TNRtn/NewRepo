IF OBJECT_ID('dbo.spUpdateCategories', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spUpdateCategories;
END
GO

CREATE PROCEDURE dbo.spUpdateCategories(
@Id INT , 
@Name NVARCHAR(250)
)
AS
BEGIN
    SET NOCOUNT ON;
	IF EXISTS(SELECT * FROM Category WHERE NAME=@Name AND ID<>@Id)
	BEGIN
		;THROW 50002, 'Category name already exists.', 1;
	END

    IF EXISTS(SELECT TOP 1* FROM Category WHERE ID=@ID AND IsActive=1)
	BEGIN 
		UPDATE Category SET Name= @Name WHERE ID=@Id AND IsActive=1;
	END
END
GO