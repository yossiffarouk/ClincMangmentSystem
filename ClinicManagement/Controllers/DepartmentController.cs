using ClinicManagement.Data;
using ClinicManagement.DTO;
using ClinicManagement.DTO.DepartementDtos;
using ClinicManagement.DTO.DoctorDtos;
using ClinicManagement.DTO.OfficeDtos;
using ClinicManagement.Entities;
using ClinicManagement.Services;
using ClinicMangmentSystem.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //youssef
    public class DepartmentController : ControllerBase
    {
        private readonly ClinicDbContext service;
        public DepartmentController(IDbContextService _service)
        {
            service = _service.UseMe();
        }


        // get all Departements
        [HttpGet("Get/All")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await service.Departments.Include(x=>x.Doctors).ThenInclude(x=>x.office).ToListAsync();

            var deptDTO = departments.Select(dept => new DepartmentWithDoctorsDTO
            {
                Id = dept.Id,
                deptName = dept.DeptName,
                doctors = dept.Doctors.Select(x => new DoctorWithAndOffId
                {
                    Id = x.Id,
                    Name = x.Name,
                    Phone = x.Phone,
                    Email = x.Email,
                    office =  x.office != null ? new OfficeDTO
                    {
                        Id = x.office.Id,
                        Name = x.office.Name,
                        Address = x.office.Address,
                    }:null
                }).ToList()
            }).ToList();    
            if (departments != null)
            {
                return Ok(deptDTO);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

        

        // get a particular department
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<DepartmentWithDoctorsDTO>> GetDepartmentWithEmployees([FromRoute] int id)
        {
            var deptModel = await service.Departments.Include(x => x.Doctors).ThenInclude(x=>x.office).FirstOrDefaultAsync(x => x.Id == id);
            if (deptModel == null)
            {
                return NotFound();
            }

            var deptDTO = new DepartmentWithDoctorsDTO
            {
                Id = id,
                deptName = deptModel.DeptName,
                doctors = deptModel.Doctors.Select(doctor => new DoctorWithAndOffId
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    Phone = doctor.Phone,
                    Email = doctor.Email,
                    office = doctor.office != null ? new OfficeDTO
                    {
                        Id = doctor.office.Id,
                        Name = doctor.office.Name,
                        Address = doctor.office.Address,
                    }: null
                }).ToList()
            };

            if(deptDTO != null)
            {
                return Ok(deptDTO);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }



        // udpdate name
        [HttpPut("Update/Name/{id}")]
        public async Task<ActionResult<IEnumerable<Department>>> UpdateDepartmentName([FromRoute]int id,[FromBody]DepartmentDTO Department)
        {
            var department = await service.Departments.FirstOrDefaultAsync(x=>x.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            department.DeptName = Department.DeptName;
            
            await service.SaveChangesAsync();
            var deptDto = new DepartmentDTO
            {
                Id = department.Id,
                DeptName = department.DeptName
            };
            return Ok(deptDto); 
        }



        // add new deparment
        [HttpPost("Add")]
        public async Task<ActionResult<IEnumerable<Department>>> AddDepartment([FromBody]DepartmentDTO dept)
        {
            if(ModelState.IsValid)
            {
                var department = new Department()
                {
                    Id = dept.Id,
                    DeptName = dept.DeptName,
                };

                service.Add(department);
                await service.SaveChangesAsync();

                var deptDto = new DepartmentDTO
                {
                    Id = department.Id,
                    DeptName = department.DeptName
                };
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }



        // delete department
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<IEnumerable<Department>>> DeleteDepartment([FromRoute]int id)
        {
            try
            {
                var department = await service.Departments.FirstOrDefaultAsync(_ => _.Id == id);
                if (department != null)
                {
                    service.Remove(department);
                    await service.SaveChangesAsync();
                    var deptDto = new DepartmentDTO
                    {
                        Id = department.Id,
                        DeptName = department.DeptName
                    };
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
