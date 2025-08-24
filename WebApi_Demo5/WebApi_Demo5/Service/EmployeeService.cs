using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Demo5.Models.WebApi_Demo4.Models;
using WebApi_Demo5.Repository;

namespace WebApi_Demo5.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly AppDbContext _db;
        public EmployeeService(AppDbContext db)
        {
            _db = db;
        }

       public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {

            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

       

        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            if (_db.Employees == null) 
            {
                return null;
            }
            return await _db.Employees.Include(e => e.Department).ToListAsync();    

        }


public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        if (_db.Employees == null)
        {
            return null;
        }

        var emp = await _db.Employees
                           .Include(e => e.Department)
                           .FirstOrDefaultAsync(e => e.Id == id);

        if (emp == null)
        {
            return null;
        }

        return emp;
    }

        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            if (_db.Employees == null)
            {
                return null;
            }
            _db.Entry(employee).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return employee;
        }
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            if (_db.Employees == null)
            {
                return null;
            }
            var emp = _db.Employees.Find(id);
            if (emp == null)
            {
                return null;
            }
            _db.Employees.Remove(emp);
            await _db.SaveChangesAsync();
            return emp;
        }



    }

}
