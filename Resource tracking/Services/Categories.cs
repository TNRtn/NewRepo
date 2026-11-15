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
        public List<Category_Result_params> GetCategories(Category_Result_params categoryInput)
        {
            try
            {
                var result = cs.Database
                    .SqlQueryRaw<Category_Result_params>(
                        "EXEC dbo.spGetCategories @Id = {0}, @Name = {1}",
                        categoryInput.Id,
                        categoryInput.Name
                    )
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving categories: {ex.Message}", ex);
            }
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
                cs.Database.ExecuteSqlRaw("EXEC spdeleteCategory @Id={0}", id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting category : {ex.Message}");
            }
        }

        public void UpdateCategory(int? id, string name)
        {
            try
            {
                cs.Database.ExecuteSqlRaw("EXEC dbo.spUpdateCategories @Id={0}, @Name={1}", id, name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating category: {ex.Message}", ex);
            }
        }
    }
}
