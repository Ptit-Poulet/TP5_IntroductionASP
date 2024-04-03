using Microsoft.AspNetCore.Mvc;

namespace IntroductionASP.Areas.Administration.Controllers
{
    public class MenuChoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
