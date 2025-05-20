using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDemo5_Advance.Models;
using MVCDemo5_Advance.Service;

namespace MVCDemo5_Advance.Controllers
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
        public IActionResult Edit(int id) 
        {
           var model = _emp.GetEmployee(id);
           var dept = _emp.GetDepartments();
           ViewData["DepartmentId"] = new SelectList(dept, "Id", "Name", model.DepartmentId);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid) 
            {
                _emp.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            var dept = _emp.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(dept, "Id", "Name", emp.DepartmentId);
            return View(emp);
        }
        public IActionResult Delete(int id)
        {
         var  model = _emp.DeleteEmployee(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult Deletedata(int id)
        {

            try
            {       
                    var model = _emp.DeleteEmployee(id);
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Create()
        {
            var dept = _emp.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(dept, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _emp.AddEmployee(emp);
                return RedirectToAction("Index");

            }
            var dept = _emp.GetDepartments();
            ViewData["DepartmentId"] = new SelectList(dept, "Id", "Name", emp.DepartmentId);
            return View(emp);
        }

    }
}
