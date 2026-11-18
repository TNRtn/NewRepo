IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA='dbo' AND TABLE_NAME='Menu')
BEGIN
CREATE TABLE Menu
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    UrlPath NVARCHAR(300) NOT NULL,
    ProjectId INT NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_Menu_Project
    FOREIGN KEY (ProjectId)
    REFERENCES Project(Id)
);
END

INSERT INTO Menu (Name, UrlPath, ProjectId)
VALUES ('Dashboard', '/upsc/dashboard', 1);

INSERT INTO Menu (Name, UrlPath, ProjectId)
VALUES ('Category', '/upsc/Category', 1);

INSERT INTO Menu (Name, UrlPath, ProjectId)
VALUES ('Resources', '/upsc/Resources', 1);

INSERT INTO Menu (Name, UrlPath, ProjectId)
VALUES ('TimePeriods', '/upsc/Timeperiods', 1);

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='dbo' AND TABLE_SCHEMA='Menu' AND   COLUMN_NAME ='IsDefault')
BEGIN
		ALTER TABLE Menu
		ADD IsDefault BIT NOT NULL
		CONSTRAINT DF_Menu_IsDefault DEFAULT 0;
END

SELECT *  FROM Menu
SELECT * FROM PROJECT
SELECT * FROM MENU
INSERT INTO dbo.Menu
(
    Name,
    UrlPath,
    ProjectId,
    IsActive,
    IsDefault
)
VALUES
(
    'DashBoard',
    '/daily-health/dashboard',
    3,
    1,
    1
);

INSERT INTO dbo.Menu
(
    Name,
    UrlPath,
    ProjectId,
    IsActive,
    IsDefault
)
VALUES
(
    'Weight Check',
    '/daily-health/weightcheck',
    3,
    1,
    0
);
