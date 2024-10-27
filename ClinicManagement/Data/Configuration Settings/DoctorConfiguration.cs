using ClinicMangmentSystem.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configuration_Settings
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("tblDoctor");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x=>x.Name).IsRequired()
                .HasMaxLength(50).HasColumnType("varchar(50)");

            builder.Property(x => x.Phone).IsRequired()
                .HasMaxLength(50).HasColumnType("varchar(50)");

            builder.Property(x => x.Email).IsRequired(false)
                .HasMaxLength(50).HasColumnType("varchar(50)");

            builder.Property(x => x.Password).IsRequired()
                .HasMaxLength(20).HasColumnType("varchar(20)");

            builder.HasMany(x=>x.Prescriptions)
                .WithOne(x=>x.Doctor)
                .HasForeignKey(x=>x.DoctorId)
                .IsRequired();

            builder.HasMany(x=>x.SchedualeTimes)
                .WithOne(x=>x.Doctor)
                .HasForeignKey(x=>x.DoctorId)
                .IsRequired();

            builder.HasOne(x=>x.office)
                .WithOne(x=>x.Doctor)
                .HasForeignKey<Doctor>(x=>x.officeId)
                .IsRequired(false);

            builder.HasOne(x=>x.department)
                .WithMany(x=>x.Doctors)
                .HasForeignKey(x=>x.DeptId)
                .IsRequired();

            builder.HasData(SeedingData.LoadDoctors());
        }
    }
}
