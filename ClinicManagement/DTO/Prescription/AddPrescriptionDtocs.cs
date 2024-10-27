using ClinicMangmentSystem.Entites;

namespace ClinicManagement.DTO.Prescription
{
    public class AddPrescriptionDtocs
    {
        //public int Id { get; set; }
        public string medicationName { get; set; } = null!;
        public string instructions { get; set; } = null!;
        public string Duration_of_treatment { get; set; } = null!;


        public int DoctorId { get; set; }



        public int PatientId { get; set; }

    }
}
