using CrudEntityWebApp.Models;
using CrudEntityWebApp.Repository;

namespace CrudEntityWebApp.Services
{
    public class EmployeeServices : IEmployee
    {


        private readonly AppDbContext db;

        public EmployeeServices(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return db.Employees.Find(id);
        }
    }
}


