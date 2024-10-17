using ClinicMangmentSystem.Entites;

namespace ClinicManagement.Entities
{
    public class Department
    {
        // Department Data
        public int Id { get; set; }
        public string DeptName { get; set; } = null!;

        // Department Relationships
        public ICollection<Doctor> Doctors { get; set; }=new List<Doctor>();
    }
}
