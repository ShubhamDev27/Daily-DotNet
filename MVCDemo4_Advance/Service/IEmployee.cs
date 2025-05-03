using MVCDemo4_Advance.Models;

namespace MVCDemo4_Advance.Service
{
    public interface IEmployee
    {
        IEnumerable<Employee> Employees();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int id);
        IEnumerable<Department> GetDepartments();
       

    }
}
 
