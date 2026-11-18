using Microsoft.AspNetCore.Mvc;
using Resource_tracking.Models;
using Resource_tracking.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Resource_tracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Health : ControllerBase
    {
        private readonly HealthService hs;
        public Health(HealthService hs) { 
            this.hs = hs;
        }

        [HttpGet]
        public IActionResult GetHealthMeasurements()
        {
            var result = new Operational_Result<List<HealthMeasurement_Result>>();
            try
            {
                 result.Data = hs.GetHealthMeasurements();
                result.Message = "Resources retrieved successfully.";
                result.IsSuccess = true;

                return Ok(result);
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while retrieving resources.";
                result.Error = ex.Message;

                return BadRequest(result);
            }

         
        }

        [HttpPost]
        public Operational_Result<string> AddHealthMeasurement([FromBody] HealthMeasurement_Input_Params input)
        {
            var result = new Operational_Result<string>();
            try
            {
                hs.AddHealthMeasurement(input);
                result.IsSuccess = true;
                result.Message = "weight added successfully.";
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while adding weight.";
                result.Error = ex.Message;

            }
            return result;
        }

        [HttpGet("MissingDates")]
        public IActionResult GetMissingHealthMeasurementDates([FromQuery] DateTime startDate,[FromQuery] DateTime? endDate)
        {
            var result = new Operational_Result<List<HealthMeasurement_MissingDate_Result>>();
            try
            {
                result.Data = hs.GetMissingHealthMeasurementDates(
                   startDate,
                   endDate ?? DateTime.Today);
                result.IsSuccess = true;
                result.Message = "notification data received";
                return Ok(result);

            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while  getting notification.";
                result.Error = ex.Message;

                return BadRequest(result);
            }
        }
    }
}
