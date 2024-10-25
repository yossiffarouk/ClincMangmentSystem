using ClinicMangmentSystem.Entites;
using System.Numerics;
using static ClinicMangmentSystem.Enums.state;

namespace ClinicManagement.Entities
{

    public class Appointment
    {
        public int Id { get; set; }
        public string Reason { get; set; } = null!;
        public State State { get; set; }
        public double Price { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }= null!;

        public int PatientId { get; set; }
        public Patient Patient { get; set; }=null!;

        public DateTime Time { get; set; } = DateTime.Now;
    }
}
