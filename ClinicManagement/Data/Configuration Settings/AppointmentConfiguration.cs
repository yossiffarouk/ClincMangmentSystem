using ClinicManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ClinicMangmentSystem.Enums.state;

namespace ClinicManagement.Data.Configuration_Settings
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("tblAppointments");

            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();

            builder.Property(x => x.Reason).HasMaxLength(50)
                .HasColumnType("Varchar(50)").HasColumnName("Cause Of Disease")
                .IsRequired();

            builder.Property(x => x.State)
                .HasConversion(
                    x=>x.ToString(),
                    x=>(State) Enum.Parse(typeof(State),x)
                );

            builder.Property(x => x.Price).HasColumnType("Decimal(15,2)")
                .IsRequired();

            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.Appointments)
                .HasForeignKey(x => x.DoctorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x=>x.Patient)
                .WithMany(x=>x.Appointments)
                .HasForeignKey(x=>x.PatientId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasData(SeedingData.LoadOfAppointmets());
        }
    }
}
