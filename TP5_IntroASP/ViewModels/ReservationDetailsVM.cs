using TP5_IntroASP.DataAccessLayer;
using TP5_IntroASP.Models;

namespace TP5_IntroASP.ViewModels
{
    public class ReservationDetailsVM
    {
        public List<Menuchoices>? Menuchoices { get; set; }
        public int choix { get; set; }
        public Reservations reservation { get; set; }

        public ReservationDetailsVM(int choix, Reservations reservation)
        {
            this.choix = choix;
            this.reservation = reservation;

        }
        //public Menuchoices GetMenuchoicesName(int id)
        //{
        //    DAL dal = new DAL();
        //    Menuchoices description = dal.MenuchoicesFact.GetMenuchoiceDescription(id);
        //    return description;
        //}
    }
}
