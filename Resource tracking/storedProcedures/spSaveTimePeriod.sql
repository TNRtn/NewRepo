IF OBJECT_ID('dbo.spSaveTimePeriod', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spSaveTimePeriod;
END
GO
CREATE OR ALTER PROCEDURE dbo.spSaveTimePeriod
(
    @Id INT = NULL,
    @Name NVARCHAR(200),
    @PeriodDate DATE,
    @Description NVARCHAR(MAX) = NULL,
    @CategoryId INT,
    @KeyNotes NVARCHAR(MAX) = NULL,
    @KeyReferenceLinks NVARCHAR(MAX) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        -- UPDATE when Id exists
        IF ISNULL(@Id, 0) > 0
        BEGIN

            IF NOT EXISTS (
                SELECT 1
                FROM dbo.TimePeriods
                WHERE Id = @Id AND IsActive = 1
            )
            BEGIN
                THROW 50001, 'Time Period not found.', 1;
            END;

            UPDATE dbo.TimePeriods
            SET
                Name = @Name,
                PeriodDate = @PeriodDate,
                Description = @Description,
                CategoryId = @CategoryId,
                KeyNotes = @KeyNotes,
                KeyReferenceLinks = @KeyReferenceLinks,
                ModifiedDate = GETDATE()
            WHERE Id = @Id;

            SELECT
                @Id AS Id,
                'Time Period updated successfully.' AS Message;
        END

        -- INSERT when Id is NULL or 0
        ELSE
        BEGIN

            INSERT INTO dbo.TimePeriods
            (
                Name,
                PeriodDate,
                Description,
                CategoryId,
                KeyNotes,
                KeyReferenceLinks,
                IsActive,
                CreatedDate
            )
            VALUES
            (
                @Name,
                @PeriodDate,
                @Description,
                @CategoryId,
                @KeyNotes,
                @KeyReferenceLinks,
                1,
                GETDATE()
            );

            SET @Id = SCOPE_IDENTITY();

            SELECT
                @Id AS Id,
                'Time Period added successfully.' AS Message;
        END

    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END
GO
