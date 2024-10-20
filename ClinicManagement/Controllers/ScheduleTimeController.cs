using ClinicManagement.Data;
using ClinicManagement.DTO;
using ClinicManagement.DTO.DoctorDtos;
using ClinicManagement.DTO.SchedualeTimeDtos;
using ClinicManagement.Services;
using ClinicMangmentSystem.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleTimeController : ControllerBase
    {
        private readonly ClinicDbContext service;

        public ScheduleTimeController(IDbContextService _service)
        {
            service = _service.UseMe();
        }


        // get all Scheduale times 
        [HttpGet("Get/All")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> GetScheduleTimes()
        {
            var scdTimes = await service.schedualeTimes.Include(x=>x.Doctor).ToListAsync();
            var SchedualTimes = scdTimes.Select(s => new SchedualeTimeDTO
            {
                Id = s.Id,
                Day = s.Day.ToString(),
                StartAt = s.TimeSlot.StartAt,
                EndAt = s.TimeSlot.EndAt,
                Doctors = s.Doctor != null ? new DoctorWithSchedualeTimeDTO
                {
                    Id = s.Doctor.Id,
                    Name = s.Doctor.Name,
                    Phone = s.Doctor.Phone,
                    Email = s.Doctor.Email
                } : null
            }).ToList();
            if(SchedualTimes != null)
            {
                return Ok(SchedualTimes);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }



        // get a particular scheduale time
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> GetSchedualeTime()
        {
            return Ok();
        }
    }
}
