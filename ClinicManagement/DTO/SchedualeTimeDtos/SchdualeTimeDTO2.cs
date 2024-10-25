using ClinicManagement.Enumes;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicManagement.DTO.SchedualeTimeDtos
{
    public class SchdualeTimeDTO2
    {
        public int Id {  get; set; }
        public string Day { get; set; } = null!;
        public string StartAt { get; set; }=null!;
        public string EndAt { get; set; } = null!;
        public int DoctorId { get; set; }
    }
}
