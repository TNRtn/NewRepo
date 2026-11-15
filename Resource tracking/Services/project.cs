using Microsoft.EntityFrameworkCore;
using Resource_tracking.Data;
using Resource_tracking.Models;

namespace Resource_tracking.Services
{
    public class projectService
    {
        public readonly AppDbContext cs;
        public projectService(AppDbContext cs)
        {
            this.cs = cs;
        }

        public List<Project_params> GetProject()
        {
            try
            {
                return cs.Database.SqlQueryRaw<Project_params>("EXEC spGetProjects").ToList();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving Projects: {ex.Message}", ex);
            }
        }
    }
}
