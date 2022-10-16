using Microsoft.AspNetCore.Mvc;

namespace testASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
