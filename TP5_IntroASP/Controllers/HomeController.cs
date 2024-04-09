using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP5_IntroASP.DataAccessLayer;
using TP5_IntroASP.Models;

namespace TP5_IntroASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DAL dal = new DAL();
            List<Menuchoices> choix = dal.MenuchoicesFact.GetAll();
            return View(choix);
        }
        public IActionResult GetReservation(int id)
        {
            DAL dal = new DAL();
            Reservations reservation = dal.ReservationFact.Get(id);
            return View(reservation);   
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}