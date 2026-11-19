using Microsoft.AspNetCore.Mvc;
using Resource_tracking.Models;
using Resource_tracking.Services;

namespace Resource_tracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UPSCTargetsController : ControllerBase
    {
        private readonly TargetService hs;

        public UPSCTargetsController(TargetService targetService)
        {
            hs = targetService;
        }

        // GET: api/UPSCTargets
        [HttpGet]
        public IActionResult GetUPSCTargets(
            [FromQuery] int? id,
            [FromQuery] bool? isActive)
        {
            var result = new Operational_Result<List<Target_Result>>();

            try
            {
                result.Data = hs.GetUPSCTargets(id, isActive);
                result.IsSuccess = true;
                result.Message = "UPSC targets retrieved successfully.";

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error occurred while retrieving UPSC targets.";
                result.Error = ex.Message;

                return BadRequest(result);
            }
        }

        // POST: api/UPSCTargets
        [HttpPost]
        public Operational_Result<string> AddUPSCTarget(
            [FromBody] Target_Input_Params input)
        {
            var result = new Operational_Result<string>();

            try
            {
                hs.AddUPSCTarget(input);

                result.IsSuccess = true;
                result.Message = "UPSC target added successfully.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error occurred while adding UPSC target.";
                result.Error = ex.Message;
            }

            return result;
        }
    }
}