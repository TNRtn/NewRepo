using Microsoft.EntityFrameworkCore;
using Resource_tracking.Data;
using Resource_tracking.Models;

namespace Resource_tracking.Services
{
    public class Categories
    {
        private readonly AppDbContext cs;

        public Categories(AppDbContext cs)
        {
            this.cs = cs;
        }
        public List<Category_Result_params> GetCategories()
        {
            var result = new List<Category_Result_params>();

            try
            {
                result = cs.Category
                           .FromSqlRaw("EXEC dbo.spGetCategories")
                           .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving categories: {ex.Message}", ex);
            }

            return result;
        }

        public void AddCategory(string name)
        {
            try
            {
                cs.Database.ExecuteSqlRaw("EXEC dbo.spAddCategories @p0", name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding category: {ex.Message}", ex);
            }

        }

        public void DeleteCategory(int id)
        {
            try
            {
                cs.Database.SqlQueryRaw<bool>("EXEC spdeleteCategory @Id={0}", id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting category : {ex.Message}");
            }
        }
    }
}
