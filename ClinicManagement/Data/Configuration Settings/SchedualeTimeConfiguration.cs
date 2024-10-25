using ClinicMangmentSystem.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ClinicManagement.Enumes.DaysEnum;

namespace ClinicManagement.Data.Configuration_Settings
{
    public class SchedualeTimeConfiguration : IEntityTypeConfiguration<SchedualeTime>
    {
        public void Configure(EntityTypeBuilder<SchedualeTime> builder)
        {
            builder.ToTable("tblSchedualeTime");

            builder.HasKey(t => t.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();

            //builder.OwnsOne(x => x.TimeSlot, x =>
            //{
            //    x.Property(x => x.StartAt).HasColumnType("Time").HasColumnName("StartTime");
            //    x.Property(x => x.EndAt).HasColumnType("Time").HasColumnName("EndTime");
            //});

            builder.Property(x => x.Day)
                .HasConversion(
                    x=>x.ToString(),
                    x=>(Days) Enum.Parse(typeof(Days), x)
                ).IsRequired();

            builder.HasData(SeedingData.LoadSchedualeTimes());
            //builder.OwnsOne(x=>x.TimeSlot).HasData(SeedingData.LoadOfTimeSlot());
        }
    }
}
