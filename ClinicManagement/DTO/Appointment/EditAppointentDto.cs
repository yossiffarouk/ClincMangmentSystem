using static ClinicMangmentSystem.Enums.state;

namespace ClinicManagement.DTO.Appointment
{
    public class EditAppointentDto
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public double Price { get; set; }
        public State State { get; set; }
        public int DoctorId { get; set; }

        public int PatientId { get; set; }
        public DateTime Time { get; set; }

    }
}
