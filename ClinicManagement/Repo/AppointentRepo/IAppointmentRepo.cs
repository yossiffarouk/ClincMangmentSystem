using ClinicManagement.DTOS.Appointment;

namespace ClinicManagement.Repo.AppointentRepo
{
    public interface IAppointmentRepo
    {
        IEnumerable<AppointmentReadDto> GetAllAppointment();
        AppointmentReadDto GetAppointmentById(int id);
        void AddAppointment(AddPrescriptionDto addAppointentDto);
        void EditAppointment(int id, EditAppointentDto appointment);
        void DeleteAppointment(int id);
    }
}
