using CrudEntityWebApp.Models;

namespace CrudEntityWebApp.Services
{
    public interface IEmployee
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAll();
       

    }
}
