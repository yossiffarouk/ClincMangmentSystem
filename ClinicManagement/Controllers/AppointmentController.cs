using ClinicManagement.Data;
using ClinicManagement.DTO.Appointment;

using ClinicManagement.Entities;

using ClinicManagement.Entities;
using ClinicManagement.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ClinicMangmentSystem.Enums.state;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        // eman
        private readonly ClinicDbContext _context;

        public AppointmentController(ClinicDbContext context)
        {
            _context = context;
        }

        // Create Appointment
        [HttpPost]
        public async Task<ActionResult<AppointmentReadDto>> AddAppointment(AddAppointentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                Reason = appointmentDto.Reason,
                Price = appointmentDto.Price,
                PatientId = appointmentDto.PatientId, // Use the PatientId from DTO
                DoctorId = appointmentDto.DoctorId,   // Use the DoctorId from DTO

            };
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return Ok("Appointment added ");
        }

        // Read All Appointments
        [HttpGet]
        public async Task<ActionResult<List<AppointmentReadDto>>> GetAllAppointments()
        {
            var appointments = _context.Appointments.Include(a => a.Doctor).ToList();
            var appointmentReadDto = appointments.Select(x => new AppointmentReadDto
            {
                Id = x.Id,
                Reason = x.Reason,
                Price = x.Price,
                State = x.State,
                Time = x.Time,
                DoctorName = x.Doctor.Name,
            });
            return Ok(appointmentReadDto);
        }

        // Read Appointment by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentReadDto>> GetAppointment(int id)
        {
            var appointment = _context.Appointments
          .Include(a => a.Doctor)
          .Include(a => a.Patient)
          .FirstOrDefault(a => a.Id == id);
            var appointmentReadDto = new AppointmentReadDto
            {
                Reason = appointment.Reason,
                Price = appointment.Price,
                State = appointment.State,
                Time = appointment.Time,
                DoctorName = appointment.Doctor.Name,
            };


            return Ok( appointmentReadDto);
        }

        // Update Appointment
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, EditAppointentDto appointmentDto)
        {
            if (id != appointmentDto.Id) return BadRequest("ID mismatch");

            var existingAppointment = _context.Appointments.FirstOrDefault(a => a.Id == id);

            existingAppointment.Reason = appointmentDto.Reason;
            existingAppointment.State = appointmentDto.State;
            existingAppointment.Price = appointmentDto.Price;
            existingAppointment.DoctorId = appointmentDto.DoctorId;
            existingAppointment.PatientId = appointmentDto.PatientId;

            _context.SaveChanges();
            return Ok("Appointment EDIT SUCCFULLY");
        }

        // Delete Appointment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return Ok("Doc removed");
        }

    }
}
