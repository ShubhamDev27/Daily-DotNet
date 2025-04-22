using MVCdemo3.Models;
using MVCdemo3.Repository;
using Microsoft.EntityFrameworkCore;

namespace MVCdemo3.Service
{
    public class IEmployeeService : IEmployee
    {
        private readonly AppDbContext _db;
        public IEmployeeService(AppDbContext db)
        {
            this._db = db;
        }

        public Employee Delete(int id)
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
            return _db.Employees;
        }

       public  Employee GetEmployee(int id)
        {
            return _db.Employees.Find(id);
        }


        public Employee Update(Employee emp1)
        {
            _db.Entry(emp1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.Update(emp1);
            _db.SaveChanges();
            return emp1;

        }
        public Employee Add(Employee emp1)
        {
            _db.Employees.Add(emp1);
            _db.SaveChanges();
            return emp1;
        }
    }
    
    
}
