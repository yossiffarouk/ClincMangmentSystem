using ClinicMangmentSystem.Entites;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicManagement.DTO.ScheduleTime
{
    public class ScheduleTimeReadDto
    {
        public int Id { get; set; }
        public string DoctorComeIn { get; set; }
        public string DoctorLeaveIn { get; set; }
        public string Day { get; set; }

        public string DoctorName { get; set; }

    }
}
