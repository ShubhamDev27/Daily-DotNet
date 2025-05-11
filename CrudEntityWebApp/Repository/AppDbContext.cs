using CrudEntityWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEntityWebApp.Repository
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Employee> Employees { get; set; }  

    }
}
