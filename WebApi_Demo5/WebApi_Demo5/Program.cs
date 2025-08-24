
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebApi_Demo5.Repository;
using WebApi_Demo5.Service;

namespace WebApi_Demo5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers().AddJsonOptions(Options=> { Options.JsonSerializerOptions.
                ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddDbContextPool<AppDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IEmployee, EmployeeService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
