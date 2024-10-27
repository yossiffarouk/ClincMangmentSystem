namespace ClinicManagement.DTO.DoctorDtos
{
    public class DoctorWithDeptIdAndOffId
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int? officeId { get; set; }

        public int DeptId { get; set; }
    }
}
