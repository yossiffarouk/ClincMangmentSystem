using ClinicManagement.Data;
using ClinicManagement.DTO.ScheduleTime;
using ClinicMangmentSystem.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleTimeController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        // saber
        public ScheduleTimeController(ClinicDbContext context)
        {
            _context = context;
        }
        // GET: api/SchedualeTime
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleTimeReadDto>>> GetSchedualeTimes()
        {
            var schedualeTimes = await _context.SchedualeTimes
                .Include(st => st.Doctor)
                .ToListAsync();

            var times = schedualeTimes.Select(x => new ScheduleTimeReadDto
            {
                Id = x.Id,
                DoctorComeIn = x.DoctorComeIn.ToString(),
                DoctorLeaveIn = x.DoctorLeaveIn.ToString(),
                Day = x.Day.ToString(),
                DoctorName=x.Doctor.Name,
            });
            return Ok(times);
        }

        // GET: api/SchedualeTime/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleTimeReadDto>> GetSchedualeTime(int id)
        {
            var schedualeTime = await _context.SchedualeTimes
                .Include(st => st.Doctor)
                .FirstOrDefaultAsync(st => st.Id == id);

            if (schedualeTime == null)
            {
                return NotFound();
            }

            var timesForDoctor = new ScheduleTimeReadDto
            {
                Id = schedualeTime.Id,
                DoctorComeIn = schedualeTime.DoctorComeIn.ToString(),
                DoctorLeaveIn = schedualeTime.DoctorLeaveIn.ToString(),
                Day = schedualeTime.Day.ToString(),
                DoctorName = schedualeTime.Doctor.Name,

            };

            return Ok(timesForDoctor);
        }

        // POST: api/SchedualeTime
        [HttpPost]
        public async Task<ActionResult> CreateSchedualeTime(AddScheduleTimeDto AddScheduleTimeDto)
        {
            // Ensure DoctorId is valid
            if (!_context.Doctors.Any(d => d.Id == AddScheduleTimeDto.DoctorId))
            {
                return BadRequest("Invalid DoctorId");
            }
            var x = new SchedualeTime {
                DoctorComeIn = TimeSpan.Parse( AddScheduleTimeDto.DoctorComeIn),
                DoctorLeaveIn= TimeSpan.Parse(AddScheduleTimeDto.DoctorLeaveIn),
                Day= AddScheduleTimeDto.Day,
                DoctorId = AddScheduleTimeDto.DoctorId,
            };

            _context.SchedualeTimes.Add(x);
            await _context.SaveChangesAsync();

            return Ok("Schedule created successfully");
        }

        // PUT: api/SchedualeTime/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedualeTime(int id, EdiScheduleTimeDto EdiScheduleTimeDto)
        {
            if (id != EdiScheduleTimeDto.Id)
            {
                return BadRequest("SchedualeTime ID mismatch.");
            }

            var existingSchedualeTime = await _context.SchedualeTimes.FindAsync(id);
            if (existingSchedualeTime == null)
            {
                return NotFound();
            }

            // Update SchedualeTime details
            existingSchedualeTime.DoctorComeIn = TimeSpan.Parse(EdiScheduleTimeDto.DoctorComeIn);
            existingSchedualeTime.DoctorLeaveIn = TimeSpan.Parse(EdiScheduleTimeDto.DoctorLeaveIn);
            existingSchedualeTime.Day = EdiScheduleTimeDto.Day;
            existingSchedualeTime.DoctorId = EdiScheduleTimeDto.DoctorId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchedualeTimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Edit Scssfully");
        }

        // DELETE: api/SchedualeTime/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedualeTime(int id)
        {
            var schedualeTime = await _context.SchedualeTimes.FindAsync(id);
            if (schedualeTime == null)
            {
                return NotFound();
            }

            _context.SchedualeTimes.Remove(schedualeTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper method to check if a SchedualeTime exists
        private bool SchedualeTimeExists(int id)
        {
            return _context.SchedualeTimes.Any(e => e.Id == id);
        }
    }
}
