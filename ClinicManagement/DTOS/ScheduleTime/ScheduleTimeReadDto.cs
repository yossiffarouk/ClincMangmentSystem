using ClinicMangmentSystem.Entites;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicManagement.DTOS.ScheduleTime
{
    public class ScheduleTimeReadDto
    {
        public int Id { get; set; }
        public TimeSpan DoctorComeIn { get; set; }
        public TimeSpan DoctorLeaveIn { get; set; }
        public string Day { get; set; }

        public string DoctorName { get; set; }
       
    }
}
