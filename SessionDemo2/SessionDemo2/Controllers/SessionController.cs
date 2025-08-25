using Microsoft.AspNetCore.Mvc;

namespace SessionDemo2.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
