using ClinicManagement.Data;
using ClinicManagement.DTO;
using ClinicManagement.DTO.DepartementDtos;
using ClinicManagement.DTO.DoctorDtos;
using ClinicManagement.DTO.OfficeDtos;
using ClinicManagement.DTO.SchedualeTimeDtos;
using ClinicManagement.Services;
using ClinicMangmentSystem.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // AHmed ibrahem
    public class DoctorController : ControllerBase
    {
        private readonly ClinicDbContext service;

        public DoctorController(IDbContextService _service)
        {
            service = _service.UseMe();
        }


       // Get All Doctors
        [HttpGet("Get/All")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorS()
        {
            var doctors = await service.Doctors
                .Include(x => x.SchedualeTimes)
                .Include(x => x.office)
                .Include(x => x.department)
                .ToListAsync();

            var docDTOs = doctors.Select(doctor => new DocDTO
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Phone = doctor.Phone,
                Email = doctor.Email,
                Office = doctor.office != null ? new OfficeDTO
                {
                    Id = doctor.office.Id,
                    Name = doctor.office.Name,
                    Address = doctor.office.Address
                } : null,
                Department =  new DepartmentDTO
                {
                    Id = doctor.department.Id,
                    DeptName = doctor.department.DeptName
                },
                SchedualeTimes = doctor.SchedualeTimes.Select(s => new SchedualeTimeDTO
                {
                    Id = s.Id,
                    Day = s.Day.ToString(),
                    StartAt = s.DoctorComeIn,
                    EndAt = s.DoctorLeaveIn
                }).ToList()
            }).ToList();

            if (docDTOs.Any())
            {
                return Ok(docDTOs);
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }


        // Get Doctor By Id
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor([FromRoute]int id)
        {
            var doctor = await service.Doctors.
                Include(x=>x.SchedualeTimes)
                .Include(x=>x.office)
                .Include(x=>x.department)
                .FirstOrDefaultAsync(x=>x.Id == id);

            var docDTO = new DocDTO
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Phone = doctor.Phone,
                Email = doctor.Email,
                Department = new DepartmentDTO
                {
                    Id = doctor.department.Id,
                    DeptName = doctor.department.DeptName
                },
                SchedualeTimes = doctor.SchedualeTimes.Select(x => new SchedualeTimeDTO
                {
                    Id = x.Id,
                    Day = x.Day.ToString(),
                    StartAt = x.DoctorComeIn,
                    EndAt = x.DoctorLeaveIn
                }).ToList(),
                Office = doctor.office !=null ? new OfficeDTO
                {
                    Id = doctor.office.Id,
                    Name = doctor.office.Name,
                    Address = doctor.office.Address,
                }:null
            };
            
            if(docDTO != null)
            {
                return Ok(docDTO);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }


        // update name , email , phone , officeId, DeptId
        [HttpPut("Update/All/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> UpdateDoctors([FromRoute] int id, [FromBody] DoctorWithDeptIdAndOffId doctor)
        {
            var doc = await service.Doctors
                .FirstOrDefaultAsync(x => x.Id == id);
            if (doc != null)
            {
                doc.Name = doctor.Name;
                doc.Phone = doctor.Phone;
                doc.Email = doctor.Email;
                doc.officeId = doctor.officeId;
                doc.DeptId = doctor.DeptId;

                await service.SaveChangesAsync();
                var docDto = new DoctorWithDeptIdAndOffId
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Email = doc.Email,
                    Phone = doc.Phone,
                    DeptId = doc.DeptId,
                    officeId = doc.officeId
                };
                return Ok(docDto);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }


        // update name only
        [HttpPatch("Update/Name/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> UpdateDoctorName([FromRoute]int id, [FromBody]DoctorWithDeptIdAndOffId doctor)
        {
            var doc = await service.Doctors
                .FirstOrDefaultAsync(x=>x.Id == id);

            if (doc != null)
            {
                doc.Name = doctor.Name;
                await service.SaveChangesAsync();

                var docDto = new DoctorWithDeptIdAndOffId
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Email = doc.Email,
                    Phone = doc.Phone,
                    DeptId = doc.DeptId,
                    officeId = doc.officeId
                };
                return Ok(docDto);
            }
            return StatusCode(StatusCodes.Status404NotFound); 
        }


        // update email only
        [HttpPatch("Update/Email/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> UpdateDoctorEmail([FromRoute]int id , [FromBody]DoctorWithDeptIdAndOffId doctor)
        {
            var doc = await service.Doctors
                .FirstOrDefaultAsync(x => x.Id == id);

            if(doc != null)
            {
                doc.Email = doctor.Email;
                await service.SaveChangesAsync();

                var docDto = new DoctorWithDeptIdAndOffId
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Email = doc.Email,
                    Phone = doc.Phone,
                    DeptId = doc.DeptId,
                    officeId = doc.officeId
                };
                return Ok(docDto);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }


        // update phone only
        [HttpPatch("Update/Phone/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> UpdateDoctorPhone([FromRoute] int id, [FromBody] DoctorWithDeptIdAndOffId doctor)
        {
            var doc = await service.Doctors
                .FirstOrDefaultAsync(x=>x.Id == id);

            if (doc != null)
            {
                doc.Phone = doctor.Phone;
                await service.SaveChangesAsync();

                var docDto = new DoctorWithDeptIdAndOffId
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Email = doc.Email,
                    Phone = doc.Phone,
                    DeptId = doc.DeptId,
                    officeId = doc.officeId
                };
                return Ok(docDto);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }


        // update OfficeId only
        [HttpPatch("Update/OfficId/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> UpdateDoctorOfficeId([FromRoute] int id, [FromBody] DoctorWithDeptIdAndOffId doctor)
        {
            var doc = await service.Doctors
                .FirstOrDefaultAsync(x => x.Id == id);

            if (doc != null)
            {
                doc.officeId = doctor.officeId;
                await service.SaveChangesAsync();

                var docDto = new DoctorWithDeptIdAndOffId
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Email = doc.Email,
                    Phone = doc.Phone,
                    DeptId = doc.DeptId,
                    officeId = doc.officeId
                };
                return Ok(docDto);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }


        // update DeptId only
        [HttpPatch("Update/DeptId/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> UpdateDoctorDeptId([FromRoute] int id, [FromBody] DoctorWithDeptIdAndOffId doctor)
        {
            var doc = await service.Doctors
                .FirstOrDefaultAsync(x => x.Id == id);

            if (doc != null)
            {
                doc.DeptId = doctor.DeptId;
                await service.SaveChangesAsync();

                var docDto = new DoctorWithDeptIdAndOffId
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Email = doc.Email,
                    Phone = doc.Phone,
                    DeptId = doc.DeptId,
                    officeId = doc.officeId
                };
                return Ok(docDto);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }



        // Add New Doctor
        //[HttpPost("Add")]
        //public async Task<ActionResult<IEnumerable<Doctor>>> PostDoctor(DoctorWithDeptIdAndOffId Doctor)
        //{
        //    var doctor = new Doctor()
        //    {
        //        Id = Doctor.Id,
        //        Name = Doctor.Name,
        //        Email = Doctor.Email,
        //        Phone = Doctor.Phone,
        //        Password = EncodingPassword(GenerateRandomPassword(12)),
        //        officeId = Doctor.officeId,
        //        DeptId = Doctor.DeptId
        //    };

        //    service.Doctors.Add(doctor);
        //    await service.SaveChangesAsync();
        //    return StatusCode(StatusCodes.Status201Created);
        //}



        // Delete a particular doctor
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> RemoveDoctor([FromRoute]int id)
        {
            try
            {
                var doctor = await service.Doctors.FirstOrDefaultAsync(x => x.Id == id);

                if (doctor != null)
                {
                    service.Doctors.Remove(doctor);
                    await service.SaveChangesAsync();
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
