using Microsoft.EntityFrameworkCore;
using MVCDemo5_Advance.Models;

namespace MVCDemo5_Advance.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
    
 }

