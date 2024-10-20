using ClinicManagement.DTO.DepartementDtos;
using ClinicManagement.DTO.OfficeDtos;
using ClinicManagement.DTO.SchedualeTimeDtos;
using ClinicManagement.Entities;
using ClinicMangmentSystem.Entites;

namespace ClinicManagement.DTO.DoctorDtos
{
    public class DocDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }

        public OfficeDTO? Office { get; set; }

        public DepartmentDTO Department { get; set; } = null!;

        public ICollection<SchedualeTimeDTO> SchedualeTimes { get; set; } = new List<SchedualeTimeDTO>();
    }
}
