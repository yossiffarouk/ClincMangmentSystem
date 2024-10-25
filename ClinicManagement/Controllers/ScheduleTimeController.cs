using ClinicManagement.Data;
using ClinicManagement.DTO;
using ClinicManagement.DTO.DepartementDtos;
using ClinicManagement.DTO.DoctorDtos;
using ClinicManagement.DTO.OfficeDtos;
using ClinicManagement.DTO.SchedualeTimeDtos;
using ClinicManagement.Enumes;
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


        // Get All Scheduale Times
        [HttpGet("Get/All")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> GetScheduleTimes()
        {
            var scdTimes = await service.schedualeTimes.Include(x => x.Doctor).ThenInclude(d => d.department) // Ensure department is included
                                                       .Include(x => x.Doctor).ThenInclude(d => d.office)    // Ensure office is included
                                                       .Include(x => x.TimeSlot) // Ensure TimeSlot is included
                                                       .ToListAsync();

            var schedualeTimeDTO = scdTimes.Select(x => new DepartementWithOffDTO
            {
                Id = x.Id,
                Day = x.Day.ToString(),
                StartAt = x.TimeSlot.StartAt, // Handle TimeSlot being null
                EndAt = x.TimeSlot.EndAt,
                Doctor = new DoctorWithSchedualeTimeDTO
                {
                    Id = x.Doctor.Id,
                    Name = x.Doctor.Name,
                    Phone = x.Doctor.Phone,
                    Email = x.Doctor.Email
                },
                departement = new DepartmentDTO
                {
                    Id = x.Doctor.department.Id,
                    DeptName = x.Doctor.department.DeptName
                },
                Office = x.Doctor?.office != null ? new OfficeDTO
                {
                    Id = x.Doctor.office.Id,
                    Name = x.Doctor.office.Name,
                    Address = x.Doctor.office.Address
                } : null
            }).ToList();

            if (schedualeTimeDTO.Any())
            {
                return Ok(schedualeTimeDTO);
            }

            return StatusCode(StatusCodes.Status404NotFound);
        }




        // Get a particular scheduale time
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> GetSchedualeTime([FromRoute] int id)
        {
            var scheduleTime = await service.schedualeTimes
                .Include(x=>x.Doctor)
                .ThenInclude(x=>x.office)
                .Include(x=>x.Doctor)
                .ThenInclude(x=>x.department)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (scheduleTime == null)
            {
                return NotFound();
            }

            var schedualeTimeDTO = scheduleTime.Doctor.SchedualeTimes.Select(x => new DepartementWithOffDTO
            {
                Id = x.Id,
                Day = x.Day.ToString(),
                StartAt = x.TimeSlot.StartAt,
                EndAt = x.TimeSlot.EndAt,
                Doctor = new DoctorWithSchedualeTimeDTO
                {
                    Name = x.Doctor.Name,
                    Phone = x.Doctor.Phone,
                    Email = x.Doctor.Email
                },
                departement = new DepartmentDTO
                {
                    DeptName = x.Doctor.department.DeptName
                },
                Office = x.Doctor.office != null ? new OfficeDTO
                {
                    Name = x.Doctor.office.Name,
                    Address = x.Doctor.office.Address
                } : null
            }); 
            return Ok(schedualeTimeDTO);
        }



        // Update scheudaleTimes [day - StartAt - EndAt - DoctorId]
        [HttpPut("Update/All/{id}")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> UpdateSchdualeTime([FromRoute]int id, [FromBody] SchdualeTimeDTO2 Times)
        {
            var scdTimes = await service.schedualeTimes
                .Include(x => x.Doctor)
                .ThenInclude(x => x.department)
                .Include(x => x.Doctor)
                .ThenInclude(x => x.office)
                .FirstOrDefaultAsync(x => x.Id == id);
            if(scdTimes == null)
            {
                return NotFound(); 
            }

            scdTimes.Day = (Days) Enum.Parse(typeof(Days),Times.Day);
            scdTimes.TimeSlot.StartAt = TimeSpan.Parse(Times.StartAt);
            scdTimes.TimeSlot.EndAt = TimeSpan.Parse(Times.EndAt);
            scdTimes.DoctorId = Times.DoctorId;

            await service.SaveChangesAsync();
            try
            {
                var ScdTimesDto = scdTimes.Doctor?.SchedualeTimes.Select(x => new OfficeWithDepartmentDTO
                {
                    Day = scdTimes.Day.ToString(),
                    StartAt = scdTimes.TimeSlot.StartAt, 
                    EndAt = scdTimes.TimeSlot.EndAt,
                    Doctor = new DoctorWithSchedualeTimeDTO
                    {
                        Id = x.Doctor.Id,
                        Name = scdTimes.Doctor?.Name, 
                        Phone = scdTimes.Doctor?.Phone,
                        Email = scdTimes.Doctor?.Email
                    }
                });
                return Ok(ScdTimesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }



        // Update schdualeTimes [day]
        [HttpPatch("Update/Day/{id}")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> UpdateSchdualeTimeDay([FromRoute]int id, [FromBody] SchdualeTimeDTO2 Times)
        {
            var scdTimes = await service.schedualeTimes
                .Include(x=>x.Doctor)
                .ThenInclude(x=>x.department)
                .Include(x=>x.Doctor)
                .ThenInclude(x=>x.office).FirstOrDefaultAsync(x=>x.Id == id);
            if(scdTimes == null)
            {
                return NotFound();
            }

            scdTimes.Day = (Days) Enum.Parse(typeof(Days),Times.Day);

            await service.SaveChangesAsync();

            try
            {
                var ScdTimesDto = scdTimes.Doctor?.SchedualeTimes.Select(x => new OfficeWithDepartmentDTO
                {
                    Day = scdTimes.Day.ToString(),
                    StartAt = scdTimes.TimeSlot.StartAt, // Handle TimeSlot being null
                    EndAt = scdTimes.TimeSlot.EndAt,
                    Doctor = new DoctorWithSchedualeTimeDTO
                    {
                        Id = x.Doctor.Id,  // Handle Doctor being null
                        Name = scdTimes.Doctor?.Name, // Handle Doctor's properties being null
                        Phone = scdTimes.Doctor?.Phone,
                        Email = scdTimes.Doctor?.Email
                    }
                });
                return Ok(ScdTimesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Update SchdualeTimes [StartAt]
        [HttpPatch("Update/StartAt/{id}")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> UpdateSchdualeTimeStartAt([FromRoute] int id , [FromBody] SchdualeTimeDTO2 Times)
        {
            var scdTimes = await service.schedualeTimes
                .Include(x => x.Doctor)
                .ThenInclude(x => x.department)
                .Include(x => x.Doctor)
                .ThenInclude(x => x.office).FirstOrDefaultAsync(x => x.Id == id);
            if (scdTimes == null)
            {
                return NotFound();
            }

            scdTimes.TimeSlot.StartAt = TimeSpan.Parse(Times.StartAt);  

            await service.SaveChangesAsync();

            var ScdTimesDto = scdTimes.Doctor?.SchedualeTimes.Select(x => new OfficeWithDepartmentDTO
            {
                Day = scdTimes.Day.ToString(),
                StartAt = scdTimes.TimeSlot.StartAt,
                EndAt = scdTimes.TimeSlot.EndAt,
                Doctor = new DoctorWithSchedualeTimeDTO
                {
                    Id = x.Doctor.Id, 
                    Name = scdTimes.Doctor?.Name, 
                    Phone = scdTimes.Doctor?.Phone,
                    Email = scdTimes.Doctor?.Email
                }
            });
            return Ok(ScdTimesDto);
        }


        // Update SchdualeTimes [EndAt]
        [HttpPatch("Update/EndAt/{id}")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> UpdateSchdualeTimeEndAt([FromRoute] int id, [FromBody] SchdualeTimeDTO2 Times)
        {
            var scdTimes = await service.schedualeTimes
                .Include(x => x.Doctor)
                .ThenInclude(x => x.department)
                .Include(x => x.Doctor)
                .ThenInclude(x => x.office).FirstOrDefaultAsync(x => x.Id == id);
            if (scdTimes == null)
            {
                return NotFound();
            }

            scdTimes.TimeSlot.EndAt = TimeSpan.Parse(Times.EndAt);

            await service.SaveChangesAsync();

            var ScdTimesDto = scdTimes.Doctor?.SchedualeTimes.Select(x => new OfficeWithDepartmentDTO
            {
                Day = scdTimes.Day.ToString(),
                StartAt = scdTimes.TimeSlot.StartAt, 
                EndAt = scdTimes.TimeSlot.EndAt,
                Doctor = new DoctorWithSchedualeTimeDTO
                {
                    Id = x.Doctor.Id, 
                    Name = scdTimes.Doctor?.Name, 
                    Phone = scdTimes.Doctor?.Phone,
                    Email = scdTimes.Doctor?.Email
                }
            });
            return Ok(ScdTimesDto);
        }



        // Update SchedualeTime [DoctorId]
        [HttpPatch("Update/DoctorId/{id}")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> UpdateSchdualeTimeDoctorId([FromRoute]int id, [FromBody]SchdualeTimeDTO2 Times)
        {
            var scdTimes = await service.schedualeTimes
                .Include(x => x.Doctor)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (scdTimes == null)
            {
                return NotFound();
            }

            scdTimes.DoctorId = Times.DoctorId; 

            await service.SaveChangesAsync();

            var ScdTimesDto = scdTimes.Doctor?.SchedualeTimes.Select(x => new OfficeWithDepartmentDTO
            {
                Day = scdTimes.Day.ToString(),
                StartAt = scdTimes.TimeSlot.StartAt,
                EndAt = scdTimes.TimeSlot.EndAt,
                Doctor = new DoctorWithSchedualeTimeDTO
                {
                    Id = x.Doctor.Id, 
                    Name = scdTimes.Doctor?.Name,
                    Phone = scdTimes.Doctor?.Phone,
                    Email = scdTimes.Doctor?.Email
                }
            });
            return Ok(ScdTimesDto);
        }

        // add schduale Time
        [HttpPost("Add")]
        public async Task<ActionResult<IEnumerable<SchedualeTime>>> AddSchdualeTime([FromBody] SchdualeTimeDTO2 times)
        {
            if (ModelState.IsValid)
            {
                var NewSchdualeTime = new SchedualeTime()
                {
                    Id  = times.Id,
                    TimeSlot = new TimeSlot { StartAt = TimeSpan.Parse(times.StartAt), EndAt = TimeSpan.Parse(times.EndAt)},
                    Day = (Days) Enum.Parse(typeof(Days),times.Day),
                    DoctorId = times.DoctorId
                };

                await  service.AddAsync(NewSchdualeTime);
                await service.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK);
            }
            return BadRequest(ModelState);
        }
    }
}
