IF OBJECT_ID('dbo.spDeleteResource', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spDeleteResource;
END
GO

CREATE PROCEDURE dbo.spDeleteResource
    @Id INT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1
        FROM Resources
        WHERE Id = @Id
    )
    BEGIN
        THROW 50001, 'Resource not found.', 1;
    END
	UPDATE Resources
	SET IsActive=0
	WHERE ID=@Id;

END
GO
