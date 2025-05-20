using MVCDemo5_Advance.Models;

namespace MVCDemo5_Advance.Service
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int id);
        IEnumerable<Department> GetDepartments();
    }
}
