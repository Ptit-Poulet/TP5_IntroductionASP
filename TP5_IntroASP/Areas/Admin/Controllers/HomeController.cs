using Microsoft.AspNetCore.Mvc;

namespace TP5_IntroASP.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
