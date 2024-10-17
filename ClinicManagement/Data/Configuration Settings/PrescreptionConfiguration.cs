using ClinicMangmentSystem.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configuration_Settings
{
    public class PrescreptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("tblPrescreption");

            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();

            builder.Property(x => x.medicationName).IsRequired()
                .HasMaxLength(40).HasColumnType("varchar(40)");

            builder.Property(x => x.instructions).IsRequired()
                .HasMaxLength(100).HasColumnType("varchar(100)");

            builder.Property(x => x.Duration_of_treatment).IsRequired()
                .HasMaxLength(50).HasColumnType("varchar(50)");

            builder.HasData(SeedingData.LoadOfPrescriptions());
        }
    }
}
