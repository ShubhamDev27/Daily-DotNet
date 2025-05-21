using Microsoft.EntityFrameworkCore;
using MVCDemo_6Advance.Models;
using MVCDemo_6Advance.Repository;

namespace MVCDemo_6Advance.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly AppDbContext _db;
        public EmployeeService(AppDbContext db)
        {
            _db = db;
        }
        public Employee AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return  employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var emp = _db.Employees.Include(e=>e.Department);
            return emp;
            
        }

        public IEnumerable<Department> Getdpartments()
        {
            return _db.Departments;
        }

        public Employee GetEmployee(int id)
        {
            var emp = _db.Employees.Include(e=>e.Department).FirstOrDefault(a=>a.Id==id);
            return emp;
        }
    }
}
