IF OBJECT_ID('dbo.spDeleteTimePeriod', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spDeleteTimePeriod;
END
GO
CREATE PROCEDURE dbo.spDeleteTimePeriod
(
    @Id INT
)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.TimePeriods
        WHERE Id = @Id
          AND IsActive = 1
    )
    BEGIN
        THROW 50001, 'Time Period not found or already deleted.', 1;
    END;

    UPDATE dbo.TimePeriods
    SET
        IsActive = 0,
        ModifiedDate = GETDATE()
    WHERE Id = @Id;

    SELECT
        @Id AS Id,
        'Time Period deleted successfully.' AS Message;
END
GO
