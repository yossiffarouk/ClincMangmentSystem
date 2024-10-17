using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleAppointmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetScheduleAppointment()
        {
            return Ok();
        }
    }
}
