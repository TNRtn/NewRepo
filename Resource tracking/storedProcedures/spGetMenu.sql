IF OBJECT_ID('dbo.spGetMenu', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spGetMenu;
END
GO

CREATE PROCEDURE dbo.spGetMenu
(
	@Id INT 
)
AS
BEGIN
	 SELECT
        Id,
        Name,
        UrlPath,
        ProjectId,
        IsDefault
    FROM Menu
    WHERE ProjectId = @Id
      AND IsActive = 1
    ORDER BY Id;
END