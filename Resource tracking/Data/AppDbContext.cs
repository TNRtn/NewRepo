using Microsoft.EntityFrameworkCore;
using Resource_tracking.Models;
namespace Resource_tracking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Category_Result_params> Category { get; set; }
        public DbSet<Resources_params_Result> Resources { get; set; }
        public DbSet<Project_params> Project { get; set; }
        public DbSet<TimePeriod_Params> TimePeriod_Params { get; set; }
    }
}
