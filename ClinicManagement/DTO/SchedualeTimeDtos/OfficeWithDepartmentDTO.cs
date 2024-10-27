using ClinicManagement.DTO.DepartementDtos;
using ClinicManagement.DTO.DoctorDtos;
using ClinicManagement.DTO.OfficeDtos;

namespace ClinicManagement.DTO.SchedualeTimeDtos
{
    public class OfficeWithDepartmentDTO
    {
        public int Id { get; set; }
        public string Day { get; set; } = null!;
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
        public DoctorWithSchedualeTimeDTO Doctor { get; set; } = null!;
    }
}
