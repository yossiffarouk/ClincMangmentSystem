using ClinicManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManagement.Data.Configuration_Settings
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("tblDepartment");

            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();

            builder.Property(x => x.DeptName).IsRequired()
                .HasMaxLength(50).HasColumnType("Varchar(50)")
                .HasColumnName("DepartmentName");

            builder.HasData(SeedingData.LoadDepartments());
        }
    }
}
