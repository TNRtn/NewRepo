IF OBJECT_ID('dbo.spdeleteCategory', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spdeleteCategory;
END
GO

CREATE PROCEDURE dbo.speleteCategory
(
    @Id INT
)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Category
        WHERE Id = @Id
    )
    BEGIN
        SELECT CAST(0 AS BIT) AS IsDeleted;
        RETURN;
    END

    UPDATE Category SET IsActive=0 WHERE ID=@Id

    SELECT CAST(1 AS BIT) AS IsDeleted;
END
GO
