using ClinicManagement.Data;
using ClinicManagement.DTOS.Appointment;
using ClinicManagement.Entities;
using ClinicManagement.Repo.AppointentRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        
        private readonly IAppointmentRepo _appointment;

        public AppointmentController(IAppointmentRepo appointment)
        {
            
            _appointment = appointment;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentReadDto>>> GetAppointments()
        {
           
            return Ok(_appointment.GetAllAppointment());
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentReadDto>> GetAppointment(int id)
        {
           
            return Ok(_appointment.GetAppointmentById(id));
        }

        // POST: api/Appointment
        [HttpPost]
        public async Task<ActionResult> CreateAppointment(AddPrescriptionDto addAppointentDto)
        {
           
            _appointment.AddAppointment(addAppointentDto);
            return Ok("new appointment added sucssfully");
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, EditAppointentDto appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest("Appointment ID mismatch.");
            }

            _appointment.EditAppointment(id, appointment);
            return Ok("Edit Succcfully");
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
           
            _appointment.DeleteAppointment(id);
            return Ok("Appointment Deleted Sucsfully");
        }

        
    }
}
