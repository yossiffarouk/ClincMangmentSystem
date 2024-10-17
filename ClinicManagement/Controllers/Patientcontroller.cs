using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Patientcontroller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPatient()
        {
            return Ok();
        }
    }
}
