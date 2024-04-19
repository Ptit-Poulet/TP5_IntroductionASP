using Microsoft.AspNetCore.Mvc;
using TP5_IntroASP.DataAccessLayer;
using TP5_IntroASP.Models;
using TP5_IntroASP.ViewModels;

namespace TP5_IntroASP.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Details(int id)
        {
            DAL dal = new DAL();
            Reservations nouvelleReservation = dal.ReservationFact.Get(id);
            Menuchoices menu = dal.MenuchoicesFact.Get(nouvelleReservation.MenuChoiceId);
            ReservationDetailsVM detail = new ReservationDetailsVM(nouvelleReservation, menu);
            
            return View(detail);
        }

    }
}
