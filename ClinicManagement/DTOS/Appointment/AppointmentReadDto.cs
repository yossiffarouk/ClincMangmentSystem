using ClinicMangmentSystem.Entites;
using static ClinicMangmentSystem.Enums.state;

namespace ClinicManagement.DTOS.Appointment
{
    public class AppointmentReadDto
    {
        public int Id { get; set; }
        public string Reason { get; set; } = null!;
        public State State { get; set; } = State.schedule;
        public double Price { get; set; }

      

        public DateTime Time { get; set; }

         public string? DoctorName { get; set; }
         //public string? PatientName { get; set; }
    }
}
