using Microsoft.EntityFrameworkCore;
using Resource_tracking.Data;
using Resource_tracking.Models;

namespace Resource_tracking.Services
{
    public class DashBoardservice
    {
        public readonly AppDbContext cs;

        public DashBoardservice(AppDbContext cs)
        {
            this.cs = cs;
        }


        public List<Dashboard_Result> GetDashboard()
        {
            try
            {
                return cs.Database
                    .SqlQueryRaw<Dashboard_Result>(
                        "EXEC dbo.spGetDashboard"
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error retrieving dashboard: {ex.Message}", ex
                );
            }
        }
    }
}
