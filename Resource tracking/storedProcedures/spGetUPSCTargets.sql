IF OBJECT_ID('dbo.spGetUPSCTargets', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetUPSCTargets;
END
GO
CREATE  PROCEDURE dbo.spGetUPSCTargets
(
    @Id INT = NULL,
    @IsActive BIT = 1
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Name,
        StartDate,
        TargetDate,
        IsActive,
        CreatedDate
    FROM dbo.Targets
    WHERE
        (@Id IS NULL OR Id = @Id)
        AND (@IsActive IS NULL OR IsActive = @IsActive)
    ORDER BY CreatedDate DESC, Id DESC;

END;
GO