using CrudEntityWebApp.Models;
using CrudEntityWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudEntityWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployee _Iemp;

        public EmployeeController(IEmployee Iemp)
        {
            _Iemp = Iemp;
        }
        public IActionResult Index()
        {
            
            var model= _Iemp.GetAll();
            return View(model);

        }

       
    }
}