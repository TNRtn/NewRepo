CREATE TABLE dbo.Resources
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    Name NVARCHAR(255) NOT NULL,

    Description NVARCHAR(MAX) NULL,

    CategoryId INT NOT NULL,

    IsActive BIT NOT NULL DEFAULT 1,

    ReferenceKeys NVARCHAR(MAX) NULL,

    ReferenceNoteLinks NVARCHAR(MAX) NULL,

    KeyPoints NVARCHAR(MAX) NULL,

    CreatedDate DATETIME2 NOT NULL DEFAULT GETUTCDATE(),

    ModifiedDate DATETIME2 NULL,

    CONSTRAINT FK_Resources_Category
        FOREIGN KEY (CategoryId)
        REFERENCES dbo.Category(Id)
);