using ClinicMangmentSystem.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configuration_Settings
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("tblOffice");

            builder.HasKey(x => x.Id);  
            builder.Property(x=>x.Id).ValueGeneratedNever();

            builder.Property(x=> x.Name).IsRequired()
                .HasMaxLength(40).HasColumnType("varchar(40)");

            builder.Property(x => x.Address).IsRequired()
                .HasMaxLength(50).HasColumnType("varchar(50)");

            builder.HasData(SeedingData.LoadOffieces());
        }
    }
}
