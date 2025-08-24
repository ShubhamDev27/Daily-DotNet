using Microsoft.AspNetCore.Mvc;
using WebApi_Demo5.Models.WebApi_Demo4.Models;

namespace WebApi_Demo5.Service
{
    public interface IEmployee
    {
        Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees();
       Task<ActionResult<Employee>> GetEmployee(int id);
        Task<ActionResult<Employee>> AddEmployee(Employee employee);

        Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee);
        Task<ActionResult<Employee>> DeleteEmployee(int id);

    }
}
