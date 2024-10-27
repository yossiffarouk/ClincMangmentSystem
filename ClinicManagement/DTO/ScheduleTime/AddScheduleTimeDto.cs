using ClinicMangmentSystem.Entites;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicManagement.DTO.ScheduleTime
{
    public class AddScheduleTimeDto
    {
        public int Id { get; set; }
        public string DoctorComeIn { get; set; }
        public string DoctorLeaveIn { get; set; }
        public Days Day { get; set; }

        // Time with Doctor (M to 1)
        public int DoctorId { get; set; }

    }
}
