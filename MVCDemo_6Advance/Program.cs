using Microsoft.EntityFrameworkCore;
using MVCDemo_6Advance.Models;
using MVCDemo_6Advance.Repository;
using MVCDemo_6Advance.Service;
using System.Text.Json.Serialization;

namespace MVCDemo_6Advance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(Options => {
                Options.JsonSerializerOptions.
                ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddDbContextPool<AppDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IEmployee, EmployeeService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
