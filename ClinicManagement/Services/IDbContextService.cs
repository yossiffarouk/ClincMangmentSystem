using ClinicManagement.Data;

namespace ClinicManagement.Services
{
    public interface IDbContextService
    {
        public ClinicDbContext UseMe();
    }
}
