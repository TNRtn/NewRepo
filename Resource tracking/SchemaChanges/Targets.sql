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

ALTER TABLE dbo.Targets
ADD CONSTRAINT CK_Targets_IsActive
CHECK (IsActive = 0 OR TargetDate >= CAST(GETDATE() AS DATE));

ALTER TABLE dbo.Targets
ADD
    IsCompleted BIT NOT NULL DEFAULT 0,
    CompletedDate DATE NULL;

ALTER TABLE dbo.Targets
ADD Score AS
(
    CASE
        WHEN IsCompleted = 0 OR CompletedDate IS NULL THEN 0
        ELSE 10 + DATEDIFF(DAY, CompletedDate, TargetDate)
    END
);

