using MVCDemo_6Advance.Models;

namespace MVCDemo_6Advance.Service
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);

        IEnumerable<Department> Getdpartments();

    }
}
