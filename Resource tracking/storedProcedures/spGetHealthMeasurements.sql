IF OBJECT_ID('dbo.spGetHealthMeasurements', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetHealthMeasurements;
END
GO
CREATE  PROCEDURE dbo.spGetHealthMeasurements
(
    @Id INT = NULL,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        MeasurementType,
        BodyPart,
        MeasurementValue,
        Unit,
        MeasurementDate,
        Notes,
        CreatedDate
    FROM dbo.HealthMeasurements
    WHERE
        (@Id IS NULL OR Id = @Id)
        AND (@StartDate IS NULL OR MeasurementDate >= @StartDate)
        AND (@EndDate IS NULL OR MeasurementDate <= @EndDate)
        AND MeasurementType = 'Body'
        AND BodyPart = 'Stomach'
    ORDER BY MeasurementDate DESC, Id DESC;

END;