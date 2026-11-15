using Microsoft.AspNetCore.Mvc;
using Resource_tracking.Models;
using Resource_tracking.Services;

namespace Resource_tracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Project : ControllerBase
    {
        public readonly projectService p;
        public Project(projectService p) { 
            this.p = p;
        }
        [HttpGet]
        public IActionResult Get() {
            var result = new Operational_Result<List<Project_params>>();
            try
            {
                var data = p.GetProject();
                result.IsSuccess = true;
                result.Message = " projects Retrived successfully";
                result.Data = data;
                return Ok(result);
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while retrieving projects.";
                result.Error = ex.Message;

                return BadRequest(result);
            }
        }
    }
}
