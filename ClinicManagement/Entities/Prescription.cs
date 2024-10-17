namespace ClinicMangmentSystem.Entites
{
    public class Prescription
    {
        public int Id { get; set; }
        public string medicationName { get; set; } = null!;
        public string instructions  { get; set; } =null!;
        public string Duration_of_treatment  { get; set; }= null!;


        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }=null!;


        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
    }
}
