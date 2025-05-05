using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDemo_6Advance.Models;
using MVCDemo_6Advance.Service;

namespace MVCDemo_6Advance.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly IEmployee _emp;
        public EmployeeController(IEmployee emp)
        {
            _emp = emp;
        }
        public IActionResult Index()
        {

            var model = _emp.GetAllEmployees();
            return View(model);
        }
       
        public IActionResult Details(int id)
        {
            var model = _emp.GetEmployee(id);
            return View(model);
        }


        public IActionResult Create()
        {
            var dept = _emp.Getdpartments();
            ViewData["DepartmentId"] = new SelectList(dept, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _emp.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            var dept = _emp.Getdpartments();
            ViewData["DepartmentId"] = new SelectList(dept, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }
    }
}
