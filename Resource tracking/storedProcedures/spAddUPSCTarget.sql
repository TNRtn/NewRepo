IF OBJECT_ID('dbo.spAddUPSCTarget', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spAddUPSCTarget;
END
GO
CREATE  PROCEDURE dbo.spAddUPSCTarget
(
    @Name NVARCHAR(100),
    @StartDate DATE,
    @TargetDate DATE,
    @IsActive BIT = 1
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@TargetDate < @StartDate)
    BEGIN
        THROW 50001, 'Target date cannot be earlier than start date.', 1;
    END;

    INSERT INTO dbo.Targets
    (
        Name,
        StartDate,
        TargetDate,
        IsActive
    )
    VALUES
    (
        @Name,
        @StartDate,
        @TargetDate,
        @IsActive
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;

END
GO