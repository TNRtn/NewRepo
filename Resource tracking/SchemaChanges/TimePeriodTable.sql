IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME='TimePeriods')
BEGIN
			CREATE TABLE dbo.TimePeriods
			(
				Id INT IDENTITY(1,1) PRIMARY KEY,

				Name NVARCHAR(200) NOT NULL,

				PeriodDate DATE NOT NULL,

				Description NVARCHAR(MAX) NULL,

				CategoryId INT NOT NULL,

				KeyNotes NVARCHAR(MAX) NULL,

				KeyReferenceLinks NVARCHAR(MAX) NULL,

				IsActive BIT NOT NULL DEFAULT 1,

				CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),

				ModifiedDate DATETIME NULL,

				CONSTRAINT FK_TimePeriods_Category
					FOREIGN KEY (CategoryId)
					REFERENCES dbo.Category(Id)
			);

END
GO
