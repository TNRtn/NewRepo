using Microsoft.AspNetCore.Mvc;
using Resource_tracking.Models;
using Resource_tracking.Services;

namespace Resource_tracking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Menu : ControllerBase
    {
        public readonly MenuService ms;

        public Menu(MenuService ms) { 
            this.ms = ms;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            var result = new Operational_Result<List<Menu_params>>();
            try
            {
                result.Data = ms.GetMenu(id);
                result.IsSuccess = true;
                result.Message = "Menu retrieved successfully.";
                return Ok(result);
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = "Error occurred while retrieving Menu.";
                result.Error = ex.Message;
                return BadRequest(result);
            }
           
        }

    }
}
