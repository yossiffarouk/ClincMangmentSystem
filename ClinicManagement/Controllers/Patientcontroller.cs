using ClinicManagement.Data;
using ClinicManagement.DTO.Patient;
using ClinicMangmentSystem.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ClinicMangmentSystem.Enums.gender;

namespace ClinicManagement.Controllers
{
    // osman
    [Route("api/[controller]")]
    [ApiController]
    public class Patientcontroller : ControllerBase
    {
        private readonly ClinicDbContext _context;

        public Patientcontroller(ClinicDbContext context)
        {
            _context = context;
        }

        // Create Patient
        [HttpPost]
        public async Task<ActionResult> AddPatient(PatientDTO patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                Age = patientDto.Age,
                gender = Enum.Parse<Gender>(patientDto.Gender),
                Phone = patientDto.Phone,
                Address = patientDto.Address
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            patientDto.Id = patient.Id;
            return Ok($"{patientDto.Name} Add Succfuly");
        }

        // Read All Patients
        [HttpGet]
        public async Task<ActionResult<List<PatientDTO>>> GetAllPatients()
        {
            return await _context.Patients
                .Select(p => new PatientDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Age = p.Age,
                    Gender = p.gender.ToString(),
                    Phone = p.Phone,
                    Address = p.Address

                }).ToListAsync();
        }

        // Read Patient by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return NotFound();

            var patientDto = new PatientDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Age = patient.Age,
                Gender = patient.gender.ToString(),
                Phone = patient.Phone,
                Address = patient.Address
            };
            return Ok(patientDto);
        }

        // Update Patient
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientDTO patientDto)
        {
            if (id != patientDto.Id) return BadRequest("ID mismatch");

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return NotFound();

            patient.Name = patientDto.Name;
            patient.Age = patientDto.Age;
            patient.gender = Enum.Parse<Gender>(patientDto.Gender);
            patient.Phone = patientDto.Phone;
            patient.Address = patientDto.Address;

            await _context.SaveChangesAsync();
            return Ok("done");
        }

        // Delete Patient
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return NotFound();

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return Ok("deleted");
        }
    }
}
