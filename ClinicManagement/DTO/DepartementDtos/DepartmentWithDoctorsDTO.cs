using ClinicManagement.DTO.DoctorDtos;

namespace ClinicManagement.DTO.DepartementDtos
{
    public class DepartmentWithDoctorsDTO
    {
        public int Id { get; set; }
        public string deptName { get; set; } = null!;
        public virtual List<DoctorWithAndOffId> doctors { get; set; } = new List<DoctorWithAndOffId>();
    }
}
