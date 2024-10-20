using ClinicManagement.DTO.DoctorDtos;
using ClinicMangmentSystem.Entites;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicManagement.DTO.SchedualeTimeDtos
{
    public class SchedualeTimeDTO
    {
        public int Id { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
        public string Day { get; set; } = null!;

        public DoctorWithSchedualeTimeDTO Doctors { get; set; }= null!;
    }
}
