using Microsoft.AspNetCore.Mvc;
using Resource_tracking.Models;
using Resource_tracking.Services;

namespace Resource_tracking.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class Dashboard : ControllerBase
    {
        private readonly DashBoardservice ds;
        public Dashboard(DashBoardservice ds)
        {
            this.ds = ds;
        }

        [HttpGet]
        public IActionResult GetDashboard()
        {
            var result = new Operational_Result<List<Dashboard_Result>>();

            try
            {
                result.Data = ds.GetDashboard();
                result.IsSuccess = true;
                result.Message = "Dashboard retrieved successfully.";

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error retrieving dashboard.";
                result.Error = ex.Message;

                return BadRequest(result);
            }
        }
    }

}
