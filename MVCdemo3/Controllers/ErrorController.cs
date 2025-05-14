using Microsoft.AspNetCore.Mvc;

namespace MVCdemo3.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpCode(int statusCode)
        {
            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the page you requested could not be found.";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry, there was an internal server error.";
                    break;
                default:
                    ViewBag.ErrorMessage = "Sorry, an unexpected error occurred.";
                    break;
            }
            return View("Not Found");
        }
    }
}
