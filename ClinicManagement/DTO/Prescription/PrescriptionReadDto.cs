using ClinicMangmentSystem.Entites;

namespace ClinicManagement.DTO.Prescription
{
    public class PrescriptionReadDto
    {
        public int Id { get; set; }
        public string medicationName { get; set; } = null!;
        public string instructions { get; set; } = null!;
        public string Duration_of_treatment { get; set; } = null!;


        public string DoctorName { get; set; }
        //public string DoctorOffice { get; set; }



        public string PatientName { get; set; }


    }
}
