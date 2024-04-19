using TP5_IntroASP.DataAccessLayer;
using TP5_IntroASP.Models;

namespace TP5_IntroASP.ViewModels
{
    public class ReservationDetailsVM
    {
        public Menuchoices Menuchoices { get; set; }
        public Reservations reservation { get; set; }

        public ReservationDetailsVM( Reservations reservation, Menuchoices menuchoices)
        {
            this.Menuchoices = menuchoices;
            this.reservation = reservation;

        }
   
    }
}
