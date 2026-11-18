using Microsoft.AspNetCore.Mvc;
using Resource_tracking.Models;
using Resource_tracking.Services;

namespace Resource_tracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimePeriod : ControllerBase
    {
        public readonly TimeperiodService ts;

        public TimePeriod(TimeperiodService ts) {
            this.ts = ts;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Timperiod_Input_params searchFilter) {
            var result = new Operational_Result<List<TimePeriod_Params>>();

            try
            {
                result.Data = ts.GetTimePeriods(searchFilter);
                result.IsSuccess = true;
                result.Message = "Menu retrieved successfully.";
                return Ok(result);
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while retrieving Timeperiods.";
                result.Error = ex.Message;
                return BadRequest(result);
            }
        }

        [HttpPost]
        public Operational_Result<string> AddTimeperiod([FromBody] Timperiod_Add_params searchFilter)
        {
            var result = new Operational_Result<string>();
            try
            {
                ts.AddTimeperiod(searchFilter);
                result.IsSuccess = true;
                result.Message = "Resource added successfully.";

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Error occurred while adding Timeperiods.";
                result.Error = ex.Message;
            }
            return result;
        }
    
    [HttpDelete("{id}")]
        public Operational_Result<string> DeleteTimeperiod([FromRoute] int id)
        {
            var result = new Operational_Result<string>();
            try
            {
                ts.deleteTimperiod(id);
                result.IsSuccess = true;
                result.Message = "timeperiod deleted successfully.";
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while deleting timeperiod.";
                result.Error = ex.Message;
            }
            return result;
        }
    }
}
