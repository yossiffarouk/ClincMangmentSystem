using ClinicMangmentSystem.Entites;
using ClinicMangmentSystem.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ClinicMangmentSystem.Enums.gender;

namespace ClinicManagement.Data.Configuration_Settings
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("tblPatient");
           
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).IsRequired()
                .HasMaxLength(50).HasColumnType("varchar(50)");

            builder.Property(x => x.Age).IsRequired();

            builder.Property(x => x.gender).HasConversion(
                    x=>x.ToString(),
                    x=>(Gender) Enum.Parse(typeof(Gender), x)
                ).IsRequired();

            builder.Property(x => x.Phone).IsRequired()
                .HasMaxLength(30).HasColumnType("varchar(30)");

            builder.Property(x => x.Address).IsRequired()
                .HasMaxLength(100).HasColumnType("varchar(100)");

            builder.HasMany(x=>x.Prescriptions)
                .WithOne(x=>x.Patient)
                .HasForeignKey(x=>x.PatientId)
                .IsRequired();

            builder.HasData(SeedingData.LoadOfPatients());
        }
    }
}
