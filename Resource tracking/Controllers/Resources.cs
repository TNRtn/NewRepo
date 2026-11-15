using Microsoft.AspNetCore.Mvc;
using Resource_tracking.Models;
using Resource_tracking.Services;

namespace Resource_tracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Resources : ControllerBase
    {
        public readonly ResourcesService _resources;
        public Resources(ResourcesService resources) {
            _resources = resources;
        }

        [HttpGet]
        public IActionResult GetResources([FromQuery] Resources_Input_params searchFilter)
        {
            var result = new Operational_Result<List<Resources_params_Result>>();

            try
            {
                var data = _resources.GetResources(searchFilter);

                result.IsSuccess = true;
                result.Message = "Resources retrieved successfully.";
                result.Data = data;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error occurred while retrieving resources.";
                result.Error = ex.Message;

                return BadRequest(result);
            }
        }

        [HttpPost]
        public Operational_Result<string> AddResource([FromBody] Resources_Add_Params searchFilter) {
            var result = new Operational_Result<string>();
            try
            {
                
                _resources.AddResources(searchFilter);
                result.IsSuccess = true;
                result.Message = "Resource added successfully.";

            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while adding Resource.";
                result.Error = ex.Message;
            }
            return result;
        }

        [HttpDelete("{id}")]
        public Operational_Result<string> DeleteResources([FromRoute]int id)
        {
            var result = new Operational_Result<string>();
            try
            {
                _resources.DeleteResource(id);
                result.IsSuccess = true;
                result.Message = " Resource deleted successfully ";

            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while updating Resource.";
                result.Error = ex.Message;
            }
            return result;
        }
    }
}
