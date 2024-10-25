using ClinicManagement;
using ClinicManagement.Data;
using ClinicManagement.Repo.AppointentRepo;
using ClinicMangmentSystem.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<ClinicDbContext>(
                builder => builder.UseSqlServer(
                            new ConfigurationBuilder().AddJsonFile("appsettings.json")
                            .Build().GetConnectionString("constr"))
            );

        //ser
        builder.Services.AddScoped<IAppointmentRepo , AppointmentRepo>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        
        app.Run();

    }
}