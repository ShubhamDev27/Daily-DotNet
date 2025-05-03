using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MVCDemo4_Advance.Models;
using MVCDemo4_Advance.Service;

namespace MVCDemo4_Advance.Controllers
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
            var model = _emp.Employees();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _emp.GetEmployee(id);
            return View(model);
        }        
        
        public IActionResult Display([FromServices] IEmployee e)
        {
            var model = e.Employees();
            return Json(model);
        }
        public ActionResult DispView()
        {
            return View();
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
        [ActionName("Edit")]
        public IActionResult Edit(Employee  emp1)
        {
           
            if (!ModelState.IsValid)
            {
                 _emp.UpdateEmployee(emp1);
                return RedirectToAction("Index");
            }
            else
            {
                var dept = _emp.GetDepartments();
                ViewData["DepartmentId"] = new SelectList(dept, "Id", "Name", emp1.DepartmentId);

                return View(emp1);
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
        public IActionResult Create(Employee emp2) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _emp.AddEmployee(emp2);
                    return RedirectToAction("Index");

                }
                else
                {
                    var dept = _emp.GetDepartments();
                    ViewData["DepartmentId"] = new SelectList(dept, "Id", "Name", emp2.DepartmentId);

                    return View(emp2);

                }
            }
            catch 
            {
                return View(emp2);

            }
            
        }
        public IActionResult Delete(int id) 
        {
        
         var model = _emp.DeleteEmployee(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteData(int id) 
        {
            try
            {
                _emp.DeleteEmployee(id);
                return RedirectToAction("Index");

            }
            catch 
            {
                return View();
            }
        
        }

    }
}
