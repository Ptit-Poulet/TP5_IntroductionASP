using Microsoft.AspNetCore.Mvc;
using TP5_IntroASP.Areas.Admin.ViewModels;
using TP5_IntroASP.DataAccessLayer;
using TP5_IntroASP.Models;

namespace TP5_IntroASP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationsController : Controller
    {
        public IActionResult List()
        {
            DAL dal = new DAL();
            List<Reservations> reservations = dal.ReservationFact.GetAll();
            return View(reservations);

        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                DAL dal = new DAL();
                Reservations? reservation = dal.ReservationFact.Get(id);

                if (reservation != null)
                {

                    return View(reservation);
                }
            }

            return View("AdminMessage", new AdminMessageVM("L'identifiant est introuvable."));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            if (id > 0)
            {
                new DAL().ReservationFact.Delete(id);
            }

            return RedirectToAction("List");
        }
    }
}
