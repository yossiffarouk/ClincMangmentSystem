using ClinicManagement.Entities;

namespace ClinicMangmentSystem.Entites
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; }=null !;
        public string? Email { get; set; }
        public string Password { get; set; }= null!;

        // Appointment with doctor (1 to M)
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        // Prescription with doctor (1 to M)
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

        // doctor table with Time table (1 to M)
        public ICollection<SchedualeTime> SchedualeTimes { get; set; } = new List<SchedualeTime>();

        //1 office with 1 doctor (1 to 1 ) 
        public int? officeId { get; set; }
        public Office? Office { get; set; }

        //1 doctor with 1 department (1 to 1)
        public int DeptId { get; set; }
        public Department Department { get; set; } = null!;
    }
}
