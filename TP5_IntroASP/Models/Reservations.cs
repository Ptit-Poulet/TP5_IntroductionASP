namespace TP5_IntroASP.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
        public int NbPersonne { get; set; }
        public DateTime DateReservation { get; set; }
        public int MenuChoiceId { get; set; }

        //Pour la désérialisation
        public Reservations()
        {

        }

        public Reservations(int id, string nom, string courriel, int nbPersonne, DateTime dateReservation, int menuChoiceId)
        {
            Id = id;
            Nom = nom;
            Courriel = courriel;
            NbPersonne = nbPersonne;
            DateReservation = dateReservation;
            MenuChoiceId = menuChoiceId;
        }
    }
}
