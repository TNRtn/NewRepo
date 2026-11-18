IF OBJECT_ID('dbo.spGetMissingHealthMeasurementDates', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetMissingHealthMeasurementDates;
END
GO
CREATE  PROCEDURE dbo.spGetMissingHealthMeasurementDates
(
    @StartDate DATE,
    @EndDate DATE = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    SET @EndDate = ISNULL(@EndDate, CAST(GETDATE() AS DATE));

    ;WITH DateList AS
    (
        SELECT @StartDate AS MissingDate
        WHERE @StartDate <= @EndDate

        UNION ALL

        SELECT DATEADD(DAY, 1, MissingDate)
        FROM DateList
        WHERE MissingDate < @EndDate
    )
    SELECT
        D.MissingDate
    FROM DateList D
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM dbo.HealthMeasurements H
        WHERE H.MeasurementDate = D.MissingDate
          AND H.MeasurementType = 'Body'
          AND H.BodyPart = 'Stomach'
    )
    ORDER BY D.MissingDate DESC
    OPTION (MAXRECURSION 0);
END;