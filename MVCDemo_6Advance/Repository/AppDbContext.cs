using Microsoft.EntityFrameworkCore;
using MVCDemo_6Advance.Models;

namespace MVCDemo_6Advance.Repository
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
