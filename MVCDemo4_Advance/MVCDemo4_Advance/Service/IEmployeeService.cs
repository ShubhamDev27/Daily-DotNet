using Microsoft.EntityFrameworkCore;
using MVCDemo4_Advance.Models;
using MVCDemo4_Advance.Repository;

namespace MVCDemo4_Advance.Service
{
    public class IEmployeeService : IEmployee
    {
        private readonly AppDbContext _db;

        public IEmployeeService(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Employee> Employees()
        {
           // return _db.Employees.Include<Employee>("Department");
            return _db.Employees.Include(a => a.Department);
        }

      
        public Employee? GetEmployee(int id)
        {
            Employee e = _db.Employees.Include(a => a.Department).FirstOrDefault(m => m.Id == id);
            return e;
        }


        public Employee UpdateEmployee(Employee emp1)
        {
            _db.Entry(emp1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.Employees.Update(emp1);
            _db.SaveChanges();
            return emp1;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return _db.Departments.ToList();
        }
        public Employee AddEmployee(Employee emp2)
        {
            _db.Employees.Add(emp2);
            _db.SaveChanges();
            return emp2;
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

      
    }
}
