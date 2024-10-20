using ClinicManagement.Data;
using ClinicManagement.Entities;
using ClinicManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ClinicDbContext service;

        public AppointmentController(IDbContextService _service)
        {
            service = _service.UseMe();
        }

        [HttpGet(Name = "GetAppointment")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
        {
            var appointment = await service.Appointments.ToListAsync();
            return Ok(appointment);
        }
    }
}
