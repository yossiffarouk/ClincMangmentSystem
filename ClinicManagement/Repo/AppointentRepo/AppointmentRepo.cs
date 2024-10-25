using ClinicManagement.Data;
using ClinicManagement.DTOS.Appointment;
using ClinicManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Repo.AppointentRepo
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ClinicDbContext _context;
        public AppointmentRepo(ClinicDbContext context)
        {
         _context = context;
        }

        public ClinicDbContext Context { get; }

        public  IEnumerable<AppointmentReadDto> GetAllAppointment()
        {
            var appointments =  _context.Appointments.Include(a => a.Doctor).ToList();
            var appointmentReadDto = appointments.Select(x => new AppointmentReadDto
            {
                Id = x.Id,
                Reason = x.Reason,
                Price = x.Price,
                State = x.State,
                Time = x.Time,
                DoctorName = x.Doctor.Name,
            });
            return appointmentReadDto;
        }



        public AppointmentReadDto GetAppointmentById(int id)
        {
            var appointment =  _context.Appointments
             .Include(a => a.Doctor)
             .Include(a => a.Patient)
             .FirstOrDefault(a => a.Id == id);
            var appointmentReadDto = new AppointmentReadDto
            {
                Reason = appointment.Reason,
                Price = appointment.Price,
                State = appointment.State,
                Time = appointment.Time,
                DoctorName = appointment.Doctor.Name,
            };


            return appointmentReadDto;
        }

        public void AddAppointment(AddPrescriptionDto addAppointentDto)
        {
            var appointment = new Appointment
            {
                Reason = addAppointentDto.Reason,
                Price = addAppointentDto.Price,
                PatientId = addAppointentDto.PatientId, // Use the PatientId from DTO
                DoctorId = addAppointentDto.DoctorId,   // Use the DoctorId from DTO
               
             };
            _context.Appointments.Add(appointment);
             _context.SaveChanges();
        }
        public void EditAppointment(int id ,EditAppointentDto appointment)
        {
            var existingAppointment =  _context.Appointments.FirstOrDefault(a=>a.Id==id);
           
            existingAppointment.Reason = appointment.Reason;
            existingAppointment.State = appointment.State;
            existingAppointment.Price = appointment.Price;
            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.PatientId = appointment.PatientId;

            // Save changes to the database
            
             _context.SaveChanges();
            
          
        }

        public void DeleteAppointment(int id)
        {
            var appointment =  _context.Appointments.FirstOrDefault(a=>a.Id == id);
            _context.Appointments.Remove(appointment);
            _context.SaveChangesAsync();
        }
       
    }
}
