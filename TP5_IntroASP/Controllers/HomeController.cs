using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;
using TP5_IntroASP.DataAccessLayer;
using TP5_IntroASP.Models;
using TP5_IntroASP.ViewModels;

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
            ReservationVM reservationVM = new ReservationVM(dal.MenuchoicesFact.GetAll(), null);
            return View(reservationVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ReservationVM reservationVM)
        { 
            if (reservationVM != null)
            {
                DAL dal = new DAL();
                Reservations? existe = dal.ReservationFact.Get(reservationVM.Reservation.Id);

                if (existe != null && existe.Id == reservationVM.Reservation.Id)
                {
                    ModelState.AddModelError("Id", "Cette réservation est déja faite.");
                }

                if (!ModelState.IsValid)
                {

                    return View("Index", reservationVM.Reservation);
                }

                dal.ReservationFact.Add(reservationVM.Reservation.Nom, reservationVM.Reservation.Courriel, reservationVM.Reservation.NbPersonne, reservationVM.Reservation.DateReservation, reservationVM.Reservation.MenuChoiceId);
            }
            Reservations nouvelleReservastion = reservationVM.Reservation;
            return RedirectToAction("Details", nouvelleReservastion);
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