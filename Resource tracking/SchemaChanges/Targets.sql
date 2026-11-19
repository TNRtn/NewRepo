IF NOT EXISTS
(
    SELECT 1
    FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_SCHEMA = 'dbo'
      AND TABLE_NAME = 'Targets'
)
BEGIN

    CREATE TABLE dbo.Targets
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,

        Name NVARCHAR(100) NOT NULL,

        StartDate DATE NOT NULL,

        TargetDate DATE NOT NULL,

        IsActive BIT NOT NULL DEFAULT 1,

        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

        CONSTRAINT CK_UPSCTargets_Dates
        CHECK (TargetDate >= StartDate)
    );

END;
GO
