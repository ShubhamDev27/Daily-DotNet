using Microsoft.EntityFrameworkCore;
using MVCDemo5_Advance.Models;
using MVCDemo5_Advance.Repository;

namespace MVCDemo5_Advance.Service
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
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var emp = _db.Employees.Find(id);
            if (emp != null)
            {
                _db.Employees.Remove(emp);
                _db.SaveChanges();
            }
           
            return emp;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var emp= _db.Employees.Include(e => e.Department);
            return emp;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _db.Departments;
        }

        public Employee GetEmployee(int id)
        {
            var emp = _db.Employees.Include(e=>e.Department).FirstOrDefault(e => e.Id == id);
            return emp;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _db.Entry(employee).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.Update(employee);
            _db.SaveChanges();
            return employee;
        }
    }
}
