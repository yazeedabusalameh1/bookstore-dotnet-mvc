using Microsoft.AspNetCore.Mvc;

namespace ProjectForTraining.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}


