IF OBJECT_ID('dbo.spGetDashboard', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetDashboard;
END
GO
CREATE  PROCEDURE dbo.spGetDashboard
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        (SELECT COUNT(*) FROM dbo.Category) AS TotalCategories,

        (SELECT COUNT(*)
         FROM dbo.Resources
         WHERE IsActive = 1) AS TotalResources,

        -- Overall revision counts
        (SELECT COUNT(*) FROM dbo.Resources
         WHERE IsActive = 1 AND RevisionCount = 0) AS Revision0Count,

        (SELECT COUNT(*) FROM dbo.Resources
         WHERE IsActive = 1 AND RevisionCount = 1) AS Revision1Count,

        (SELECT COUNT(*) FROM dbo.Resources
         WHERE IsActive = 1 AND RevisionCount = 2) AS Revision2Count,

        (SELECT COUNT(*) FROM dbo.Resources
         WHERE IsActive = 1 AND RevisionCount = 3) AS Revision3Count,

        (SELECT COUNT(*) FROM dbo.Resources
         WHERE IsActive = 1 AND RevisionCount = 4) AS Revision4Count,

        (SELECT COUNT(*) FROM dbo.Resources
         WHERE IsActive = 1 AND RevisionCount = 5) AS Revision5Count,

        C.Id AS CategoryId,
        C.Name AS CategoryName,
        COUNT(R.Id) AS ResourceCount

    FROM dbo.Category C

    LEFT JOIN dbo.Resources R
        ON C.Id = R.CategoryId
        AND R.IsActive = 1

    GROUP BY C.Id, C.Name
    ORDER BY C.Name;
END
GO