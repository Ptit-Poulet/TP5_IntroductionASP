using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TP5_IntroASP.Models
{
    public class Reservations
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le nom est requis.")]
        [StringLength(20, ErrorMessage = "Le nom ne doit pas avoir plus de {1} caractères.")]
        public string Nom { get; set; }

        [Display(Name = "Courriel")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le courriel est requis.")]
        [StringLength(50, ErrorMessage = "Le courriel ne doit pas avoir plus de {1} caractères.")]
        public string Courriel { get; set; }

        [Display(Name = "Nombre")]
        [Range(1, short.MaxValue, ErrorMessage = "Le nombre de personne doit être positif.")]
        [Required(ErrorMessage = "Le nombre de personne est requis.")]
        public int NbPersonne { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La date de réservation est requises.")]
        public DateTime DateReservation { get; set; }

        [Display(Name = "Choix de menu")]
        [Range(1, short.MaxValue, ErrorMessage = "Le choix de menu est requis.")]
        [Required(ErrorMessage = "Le choix de menu est requis.")]
        public int MenuChoiceId { get; set; }

        public string? MenuDescription { get; set; }

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
