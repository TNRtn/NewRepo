IF OBJECT_ID('dbo.spAddResource', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spAddResource;
END
GO

CREATE PROCEDURE dbo.spAddResource
    @Id INT = NULL,
    @Name NVARCHAR(200),
    @Description NVARCHAR(MAX),
    @CategoryId INT,
    @ReferenceKeys NVARCHAR(MAX) = NULL,
    @ReferenceNoteLinks NVARCHAR(MAX) = NULL,
    @KeyPoints NVARCHAR(MAX) = NULL,
	@revisionCount INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF(@Id IS  NULL OR @Id<=0)
    BEGIN
        INSERT INTO dbo.Resources
        (
            Name,
            Description,
            CategoryId,
            IsActive,
            ReferenceKeys,
            ReferenceNoteLinks,
            KeyPoints,
            RevisionCount,
            CreatedDate
        )
        VALUES
        (
            @Name,
            @Description,
            @CategoryId,
            1,
            @ReferenceKeys,
            @ReferenceNoteLinks,
            @KeyPoints,
            0,
            GETDATE()
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
    END
    ELSE
    BEGIN
        UPDATE dbo.Resources 
		SET 
		Name = @Name,
		Description = @Description,
		@CategoryId = @CategoryId,
		ReferenceKeys = @ReferenceKeys,
		ReferenceNoteLinks = @ReferenceNoteLinks,
		KeyPoints = @KeyPoints,
		RevisionCount = @revisionCount,
		ModifiedDate = GETDATE()
		WHERE ID= @Id
		SELECT @Id AS Id;
    END

END
GO
