using TP5_IntroASP.Models;

namespace TP5_IntroASP.ViewModels
{
    public class ReservationVM
    {
        public List<Menuchoices>? Menuchoices { get; set; }
        public Reservations Reservation { get; set; } = new Reservations();

        public ReservationVM()
        {

        }

        public ReservationVM(List<Menuchoices> menuchoices, Reservations reservation)
        {
            Menuchoices = menuchoices;
            Reservation = reservation;
        }

    }
}
