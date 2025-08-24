using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Demo5.Models.WebApi_Demo4.Models;
using WebApi_Demo5.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Demo5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _emp;
        public EmployeeController(IEmployee emp)
        {
            _emp = emp;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var emp = await _emp.GetAllEmployees();
            if (emp == null) 
            {
              return NotFound();
            }
            return emp;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var emp = await _emp.GetEmployee(id);
            if (emp == null)
            {
                return NotFound("Employee not Found");
            }
            return emp;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
        {
            await _emp.AddEmployee(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            try
            {
                await _emp.UpdateEmployee(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_emp.GetEmployee(id) == null)
                {
                    return NotFound($"Id={id}does not exist in DB to Update");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var emp = await _emp.GetEmployee(id);
            if (emp == null)
            {
                return NotFound();
            }
            await _emp.DeleteEmployee(id);
            return NoContent();


        }

    }
}
