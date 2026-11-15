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
            _catogories = cs;
        }
        [HttpGet("")]
        public Operational_Result<List<Category_Result_params>> Getcategories([FromQuery] Category_Result_params categoryInput)
        {
            var result = new Operational_Result<List<Category_Result_params>>();
            try
            {
                // Retrieve categories from database
                result.Data = _catogories.GetCategories(categoryInput);
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
        public Operational_Result<string> AddCategory([FromBody] Category_Add_Input categoryInput)
        {
            var result = new Operational_Result<string>();
            try
            {
                _catogories.AddCategory(categoryInput.Name);
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
        public Operational_Result<string> DeleteCategory([FromRoute]int id)
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

        [HttpPut("")]
        public Operational_Result<string> UpdateCategory([FromBody] Category_Result_params categoryInput)
        {
            var result = new Operational_Result<string>();
            try
            {
                _catogories.UpdateCategory(categoryInput.Id, categoryInput.Name);
                result.IsSuccess = true;
                result.Message = "Category updated successfully.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error occurred while updating category.";
                result.Error = ex.Message;
            }
            return result;
        }
    }
}
