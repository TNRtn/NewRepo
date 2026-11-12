using Microsoft.EntityFrameworkCore;
using Resource_tracking.Models;
namespace Resource_tracking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Category_Result_params> Category { get; set; }
    }
}
