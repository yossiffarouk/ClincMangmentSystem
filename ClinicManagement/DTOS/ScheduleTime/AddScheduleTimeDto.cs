using ClinicMangmentSystem.Entites;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicManagement.DTOS.ScheduleTime
{
    public class AddScheduleTimeDto
    {
        public int Id { get; set; }
        public TimeSpan DoctorComeIn { get; set; }
        public TimeSpan DoctorLeaveIn { get; set; }
        public Days Day { get; set; }

        // Time with Doctor (M to 1)
        public int DoctorId { get; set; }
       
    }
}
