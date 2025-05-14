using Microsoft.AspNetCore.Mvc;
using MVCdemo3.Models;
using MVCdemo3.Service;

namespace MVCdemo3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee emp;
        public EmployeeController(IEmployee emp)
        {
            this.emp = emp; 
        }

        public IActionResult Index()
        {
            var model = emp.GetAllEmployees();

            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = emp.GetEmployee(id);
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = emp.GetEmployee(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee emp1)
        {
            if(ModelState.IsValid)
            {
                var model = emp.Update(emp1);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var model = emp.GetEmployee(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteData(int id)
        {
            try
            {

                emp.Delete(id);
                return RedirectToAction(nameof(Index));

            }
            catch 
            {
                return View();
                    
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult Create(Employee emp4)
        {
            if (ModelState.IsValid)
            {
                var model = emp.Add(emp4);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


    }
}
