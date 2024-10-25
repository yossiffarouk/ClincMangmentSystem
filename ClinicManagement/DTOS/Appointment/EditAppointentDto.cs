using static ClinicMangmentSystem.Enums.state;

namespace ClinicManagement.DTOS.Appointment
{
    public class EditAppointentDto
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public double Price { get; set; }
        public State State { get; set; }
        public int DoctorId { get; set; }

        public int PatientId { get; set; }
    }
}
