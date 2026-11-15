IF OBJECT_ID('dbo.spGetProjects', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetProjects;
END
GO

CREATE PROCEDURE dbo.spGetProjects
AS
BEGIN
	SELECT * FROM Project WHERE IsActive=1
END