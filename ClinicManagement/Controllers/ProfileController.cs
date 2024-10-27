using ClinicManagement.Data;
using ClinicMangmentSystem.DTOS;
using ClinicMangmentSystem.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicMangmentSystem.Controllers
{
    // farouk
    //[Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ClinicDbContext _clinicDB;
        public IConfiguration _Configuration { get; }
        public ProfileController(ClinicDbContext clinicDB , IConfiguration configuration)
        {
            _clinicDB = clinicDB;
            _Configuration = configuration;
        }


        [HttpPost("Login")]
        public IActionResult login(LoginDto loginDto)
        {
          var doctor =  _clinicDB.Doctors.FirstOrDefault(x=> x.Email == loginDto.Email && x.Password == HashPassword(loginDto.password));
            if (doctor != null) 
            {
               List<Claim> claim = new  List<Claim>();

                claim.Add(new Claim("Email", loginDto.Email));
                claim.Add(new Claim(ClaimTypes.Role, "Doctor"));


                var mysecrtkey = _Configuration.GetValue<string>("SecretKeyString");
                var keytobyte = Encoding.ASCII.GetBytes(mysecrtkey);
                SecurityKey key = new SymmetricSecurityKey(keytobyte);


                SigningCredentials signingCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);


                JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                    (

                    claims: claim,
                    signingCredentials: signingCredentials,
                    expires: DateTime.Now.AddHours(4)
                    
                    );

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();


                var token = handler.WriteToken(jwtSecurityToken);


                return Ok($"welcom Dr.{doctor.Name} your token is {token}");
            }

            return Unauthorized();
        }
        [HttpPost("Registration")]
        public IActionResult Registration(RegisterDto RegisterDto)
        {

            var doctor = new Doctor
            {
                Email = RegisterDto.Email,
                Password = HashPassword(RegisterDto.Password),
                Name = RegisterDto.Name,
                Phone = RegisterDto.Phone,
                DeptId = RegisterDto.DepId,
            };
            _clinicDB.Doctors.Add(doctor);
            _clinicDB.SaveChanges();

            return Ok("doctor register scusfully");
        }


        private string HashPassword(string password)
        {

            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
