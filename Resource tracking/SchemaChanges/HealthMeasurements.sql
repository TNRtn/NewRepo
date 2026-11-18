IF NOT EXISTS
(
    SELECT *
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
      AND TABLE_NAME = 'HealthMeasurements'
)
BEGIN

    CREATE TABLE dbo.HealthMeasurements
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,

        MeasurementType NVARCHAR(20) NOT NULL,

        BodyPart NVARCHAR(30) NULL,

        MeasurementValue DECIMAL(8,2) NOT NULL,

        Unit NVARCHAR(5) NOT NULL,

        MeasurementDate DATE NOT NULL,

        Notes NVARCHAR(500) NULL,

        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

        CONSTRAINT CK_HealthMeasurements_Value
            CHECK (MeasurementValue > 0),

        CONSTRAINT CK_HealthMeasurements_Type
            CHECK (MeasurementType IN ('Body', 'Weight')),

        CONSTRAINT CK_HealthMeasurements_Unit
            CHECK (Unit IN ('cm', 'kg'))
    );

END;