IF OBJECT_ID('dbo.spSaveHealthMeasurement', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spSaveHealthMeasurement;
END
GO
CREATE  PROCEDURE dbo.spSaveHealthMeasurement
(
    @MeasurementValue DECIMAL(8,2),
    @MeasurementDate DATE,
    @Notes NVARCHAR(500) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.HealthMeasurements
    (
        MeasurementType,
        BodyPart,
        MeasurementValue,
        Unit,
        MeasurementDate,
        Notes
    )
    VALUES
    (
        'Body',
        'Stomach',
        @MeasurementValue,
        'cm',
        @MeasurementDate,
        @Notes
    );

    SELECT
        CAST(SCOPE_IDENTITY() AS INT) AS Id;

END;