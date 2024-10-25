using ClinicMangmentSystem.Entites;

namespace ClinicManagement.DTOS.Appointment
{
    public class AddPrescriptionDto
    {
        //public int Id { get; set; }
        public string Reason { get; set; }
        public double Price { get; set; } 

        public int DoctorId { get; set; }

        public int PatientId { get; set; }
        
    }
}
