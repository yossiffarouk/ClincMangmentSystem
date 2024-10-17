using ClinicManagement.Entities;
using ClinicManagement.Enumes;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicMangmentSystem.Entites
{
    public class SchedualeTime
    {
        public int Id { get; set; }
        public TimeSlot TimeSlot { get; set; }= null!;
        public Days Day { get; set; }

        // Time with Doctor (M to 1)
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }=null!;
    }
    public class TimeSlot
    {
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }

        public int SchedualeTimeId {  get; set; }
        public SchedualeTime SchedualeTime { get; set; } = null!;
    }
}
