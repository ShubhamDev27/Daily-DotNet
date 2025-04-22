using MVCdemo3.Models;

namespace MVCdemo3.Service
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Delete(int id);
        Employee Update(Employee emp1);
        Employee Add(Employee emp1);

    }
}
