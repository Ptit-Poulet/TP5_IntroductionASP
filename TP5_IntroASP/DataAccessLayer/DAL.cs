using TP5_IntroASP.DataAccessLayer.Factories;

namespace TP5_IntroASP.DataAccessLayer
{
    public class DAL
    {
        private MenuchoicesFactory _menuchoicesFact = null;
        private ReservationsFactory _reservationsFact = null;
        public static string? ConnectionString { get; set; }

        public MenuchoicesFactory MenuchoicesFact
        {
            get
            {
                if(_menuchoicesFact == null)
                {
                    _menuchoicesFact = new MenuchoicesFactory();
                }
                return _menuchoicesFact;
            }
        }

        public ReservationsFactory ReservationFact
        {
            get
            {
                if(_reservationsFact == null)
                {
                    _reservationsFact = new ReservationsFactory();
                }

                return _reservationsFact;
            }
        }
    }
}
