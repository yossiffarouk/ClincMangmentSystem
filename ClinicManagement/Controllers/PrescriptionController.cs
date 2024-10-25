using ClinicManagement.Data;
using ClinicManagement.DTOS.Prescription;
using ClinicMangmentSystem.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public PrescriptionController(ClinicDbContext context)
        {
            _context = context;
        }
        // GET: api/Prescription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrescriptionReadDto>>> GetPrescriptions()
        {
            var prescriptions = await _context.Prescriptions
                .Include(p => p.Doctor)
                .ThenInclude(p=>p.Office)
                .Include(p => p.Patient)
                .ToListAsync();

            var result = prescriptions.Select(x => new PrescriptionReadDto
            {
                Id =x.Id,
                Duration_of_treatment = x.Duration_of_treatment,
                medicationName = x.medicationName,
                DoctorName = x.Doctor.Name,
                PatientName = x.Patient.Name,
                //DoctorOffice=x.Doctor.Office.Name,
                instructions = x.instructions,


            });
            return Ok(result);
        }

        // GET: api/Prescription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionReadDto>> GetPrescription(int id)
        {
            var prescription = await _context.Prescriptions
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prescription == null)
            {
                return NotFound();
            }

            var result = new PrescriptionReadDto
            {
                Id = prescription.Id,
                Duration_of_treatment = prescription.Duration_of_treatment,
                medicationName = prescription.medicationName,
                DoctorName = prescription.Doctor.Name,
                PatientName = prescription.Patient.Name,
                //DoctorOffice=x.Doctor.Office.Name,
                instructions = prescription.instructions,


            };
            return Ok(result);
        }

        // POST: api/Prescription
        [HttpPost]
        public async Task<ActionResult> CreatePrescription(AddPrescriptionDtocs AddPrescriptionDtocs)
        {
            // Validate DoctorId and PatientId
            if (!_context.Doctors.Any(d => d.Id == AddPrescriptionDtocs.DoctorId) ||
                !_context.Patients.Any(p => p.Id == AddPrescriptionDtocs.PatientId))
            {
                return BadRequest("Invalid DoctorId or PatientId.");
            }
            var prescription = new Prescription
            {
                medicationName = AddPrescriptionDtocs.medicationName,
                Duration_of_treatment = AddPrescriptionDtocs.Duration_of_treatment,
                DoctorId = AddPrescriptionDtocs.DoctorId,
                PatientId= AddPrescriptionDtocs.PatientId,
                instructions = AddPrescriptionDtocs.instructions,

            };

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            return Ok("ADD Prescription Scusfully ");
        }

        // PUT: api/Prescription/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescription(int id, EditPrescriptionDto EditPrescriptionDto)
        {
            if (id != EditPrescriptionDto.Id)
            {
                return BadRequest("Prescription ID mismatch.");
            }

            var existingPrescription = await _context.Prescriptions.FindAsync(id);
            if (existingPrescription == null)
            {
                return NotFound();
            }

            // Update prescription details
            existingPrescription.medicationName = EditPrescriptionDto.medicationName;
            existingPrescription.instructions = EditPrescriptionDto.instructions;
            existingPrescription.Duration_of_treatment = EditPrescriptionDto.Duration_of_treatment;
            existingPrescription.DoctorId = EditPrescriptionDto.DoctorId;
            existingPrescription.PatientId = EditPrescriptionDto.PatientId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Prescription/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }

            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
