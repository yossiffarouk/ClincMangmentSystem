using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleTimeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetScheduleTime()
        {
            return Ok();
        }
    }
}
