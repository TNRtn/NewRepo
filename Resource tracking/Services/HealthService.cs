using Microsoft.EntityFrameworkCore;
using Resource_tracking.Data;
using Resource_tracking.Models;

namespace Resource_tracking.Services
{
    public class HealthService
    {
        private readonly AppDbContext cs;
        public HealthService(AppDbContext cs)
        {
            this.cs = cs;
        }
        public List<HealthMeasurement_Result> GetHealthMeasurements()
        {
            try
            {
                return cs.Database
                    .SqlQueryRaw<HealthMeasurement_Result>(
                        "EXEC dbo.spGetHealthMeasurements")
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error retrieving health measurements: {ex.Message}", ex);
         
            }
        }

        public void AddHealthMeasurement(HealthMeasurement_Input_Params input)
        {
            try
            {
                var result = cs.Database
                    .SqlQueryRaw<HealthMeasurement_Insert_Result>(
                        @"EXEC dbo.spSaveHealthMeasurement
                        @MeasurementValue = {0},
                        @MeasurementDate = {1},
                        @Notes = {2}",
                        input.MeasurementValue,
                        input.MeasurementDate,
                        input.Notes)
                    .ToList();

                
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error adding health measurement: {ex.Message}", ex);
            }
        }

        public List<HealthMeasurement_MissingDate_Result>GetMissingHealthMeasurementDates(DateTime startDate,DateTime endDate)
        {
            try
            {
                return cs.Database
                    .SqlQueryRaw<HealthMeasurement_MissingDate_Result>(@"EXEC dbo.spGetMissingHealthMeasurementDates @StartDate = {0}, @EndDate = {1}", startDate,endDate)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error retrieving missing measurement dates: {ex.Message}", ex);
            }
        }
    }
}
