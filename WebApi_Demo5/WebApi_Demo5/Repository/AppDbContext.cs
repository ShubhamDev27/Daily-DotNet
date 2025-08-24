using Microsoft.EntityFrameworkCore;
using WebApi_Demo5.Models;
using WebApi_Demo5.Models.WebApi_Demo4.Models;

namespace WebApi_Demo5.Repository
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> Options): base(Options) 
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
