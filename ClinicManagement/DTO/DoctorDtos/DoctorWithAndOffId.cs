using ClinicManagement.DTO.OfficeDtos;
using ClinicMangmentSystem.Entites;

namespace ClinicManagement.DTO.DoctorDtos
{
    public class DoctorWithAndOffId
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        
        public OfficeDTO? office { get; set; } 
    }
}
