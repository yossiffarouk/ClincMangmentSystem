using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        [HttpGet(Name = "GetAppointment")]
        public IActionResult GetAppointment()
        {
            return Ok();
        }
    }
}
