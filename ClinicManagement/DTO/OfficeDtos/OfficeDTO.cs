using ClinicMangmentSystem.Entites;

namespace ClinicManagement.DTO.OfficeDtos
{
    public class OfficeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
