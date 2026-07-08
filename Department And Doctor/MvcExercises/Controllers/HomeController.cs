using Microsoft.AspNetCore.Mvc;

namespace MvcExercises.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
