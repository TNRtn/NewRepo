using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resource_tracking.Models;
using Resource_tracking.Services;

namespace Resource_tracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Category : ControllerBase
    {
        private readonly Categories _catogories;
        public Category(Categories cs)
        {
             _catogories= cs;
        }
        [HttpGet("")]
        public Operational_Result<List<Category_Result_params>> Getcategories()
        {
            var result = new Operational_Result<List<Category_Result_params>>();
            try
            {
                // Retrieve categories from database
                result.Data = _catogories.GetCategories();
                result.IsSuccess = true;
                result.Message = "Categories retrieved successfully.";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error occurred while retrieving categories.";
                result.Error = ex.Message;
            }
            return result;
        }
        [HttpPost("")]
        public Operational_Result<string> AddCategory(string name)
        {
            var result = new Operational_Result<string>();
            try
            {
                _catogories.AddCategory(name);
                result.IsSuccess = true;
                result.Message = "Category added successfully.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error occurred while adding category.";
                result.Error = ex.Message;
            }
            return result;
        }

        [HttpDelete("{id}")]
        public Operational_Result<string> DeleteCategory(int id)
        {
            var result = new Operational_Result<string>();
            try
            {
                _catogories.DeleteCategory(id);
                result.IsSuccess = true;
                result.Message = "Category deleted successfully.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error occurred while deleting category.";
                result.Error = ex.Message;
            }
            return result;
        }
    }
}
