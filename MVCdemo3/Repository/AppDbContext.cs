using Microsoft.EntityFrameworkCore;
using MVCdemo3.Models;

namespace MVCdemo3.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
