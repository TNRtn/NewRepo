using Microsoft.EntityFrameworkCore;
using Resource_tracking.Data;
using Resource_tracking.Models;

namespace Resource_tracking.Services
{
    public class MenuService
    {
        public readonly AppDbContext cs;
        public MenuService(AppDbContext cs)
        {
            this.cs = cs;
        }

        public List<Menu_params> GetMenu(int id)
        {
            try
            {
                return cs.Database.SqlQueryRaw<Menu_params>("EXEC spGetMenu @p0", id).ToList();
            }
            catch (Exception ex) {
                throw new Exception($"Error retrieving Menu items: {ex.Message}", ex);
            }
        }
    }
}
