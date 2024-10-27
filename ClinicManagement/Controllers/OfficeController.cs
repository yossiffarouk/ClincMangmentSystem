using ClinicManagement.Data;
using ClinicManagement.DTO.OfficeDtos;
using ClinicManagement.Services;
using ClinicMangmentSystem.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ClinicManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly ClinicDbContext service;

        public OfficeController(IDbContextService _Service)
        {
            service = _Service.UseMe();
        }


        // get All Offices
        [HttpGet("Get/All")]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffices()
        {
            var offices = await  service.Offices.ToListAsync();
            if(offices != null)
            {
                var offDto = offices.Select(x => new OfficeDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                });
                return Ok(offDto);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }



        // Get a particular office
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffice([FromRoute]int id)
        {
            var office = await service.Offices.FirstOrDefaultAsync(x => x.Id == id);
            if (office != null)
            {
                var offDto = new OfficeDTO
                {
                    Id = office.Id,
                    Name = office.Name,
                    Address = office.Address
                };
                return Ok(offDto);
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }



        // update name , location
        [HttpPut("Update/All/{id}")]
        public async Task<ActionResult<IEnumerable<Office>>> UpdateOffices([FromRoute]int id,[FromBody]OfficeDTO officedto)
        {
            var off = await service.Offices.FirstOrDefaultAsync(x => x.Id == id);

            if (off != null)
            {
                off.Name = officedto.Name;
                off.Address = officedto.Address;


                await service.SaveChangesAsync();
                var offDto = new OfficeDTO
                {
                    Id = off.Id,
                    Name = off.Name,
                    Address = off.Address
                };
                return Ok(offDto);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }



        // update name only
        [HttpPatch("Update/Name/{id}")]
        public async Task<ActionResult<IEnumerable<Office>>> UpdateOfficeName([FromRoute] int id, [FromBody]OfficeDTO office)
        {
            var off = await service.Offices.FirstOrDefaultAsync(x=>x.Id == id);

            if(off != null)
            {
                off.Name= office.Name;

                await service.SaveChangesAsync();
                var offDto = new OfficeDTO
                {
                    Id = off.Id,
                    Name = off.Name,
                    Address = off.Address
                };
                return Ok(offDto);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }



        // update address only
        [HttpPatch("Update/Address/{id}")]
        public async Task<ActionResult<IEnumerable<Office>>> UpdateOfficeAddress([FromRoute] int id, [FromBody] OfficeDTO office)
        {
            var Office = await service.Offices.FirstOrDefaultAsync(x=>x.Id == id);

            if (Office != null)
            {
                Office.Address = office.Address;

                await service.SaveChangesAsync();
                var offDto = new OfficeDTO
                {
                    Id = office.Id,
                    Name = office.Name,
                    Address = office.Address
                };
                return Ok(offDto);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }



        // add new Office
        [HttpPost("Add")]
        public async Task<ActionResult<IEnumerable<Office>>> AddOffice([FromBody]OfficeDTO officedto)
        {
            if (ModelState.IsValid)
            {
                var newOffice = new Office
                {
                    Id = officedto.Id,
                    Name = officedto.Name,
                    Address = officedto.Address
                };

                service.Offices.Add(newOffice);
                await service.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }



        // delete office
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<IEnumerable<Office>>> DeleteOffice([FromRoute]int id)
        {
            try
            {
                var off = await  service.Offices.FirstOrDefaultAsync(x => x.Id == id);
                service.Offices.Remove(off);
                await service.SaveChangesAsync();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
