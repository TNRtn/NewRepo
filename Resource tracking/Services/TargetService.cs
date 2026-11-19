using Microsoft.EntityFrameworkCore;
using Resource_tracking.Data;
using Resource_tracking.Models;

namespace Resource_tracking.Services
{
    public class TargetService
    {
        private readonly AppDbContext cs;
        public TargetService(AppDbContext cs)
        {
            this.cs = cs;
        }

        public List<Target_Result> GetUPSCTargets(
        int? id,
        bool? isActive)
        {
            try
            {
                return cs.Database
                    .SqlQueryRaw<Target_Result>(
                        @"EXEC dbo.spGetUPSCTargets
                        @Id = {0},
                        @IsActive = {1}",
                        id,
                        isActive)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error retrieving UPSC targets: {ex.Message}", ex);
            }
        }

        // Add Target
        public int AddUPSCTarget(Target_Input_Params input)
        {
            try
            {
                var result = cs.Database
                    .SqlQueryRaw<Target_Insert_Result>(
                        @"EXEC dbo.spAddUPSCTarget
                        @Name = {0},
                        @StartDate = {1},
                        @TargetDate = {2},
                        @IsActive = {3}",
                        input.Name,
                        input.StartDate,
                        input.TargetDate,
                        input.IsActive)
                    .ToList();

                return result.FirstOrDefault()?.Id ?? 0;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error adding UPSC target: {ex.Message}", ex);
            }
        }
    }
}
