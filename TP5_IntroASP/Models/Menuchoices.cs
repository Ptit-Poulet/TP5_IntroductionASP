using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TP5_IntroASP.Models
{
    public class Menuchoices
    {
        public int Id { get; set; }

        [Display(Name = "Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La descriptione est requise.")]
        [StringLength(30, ErrorMessage = "La description ne peut pas avoir plus de {1} caractères.")]
        public string Description { get; set; } = string.Empty;
        
        // Constructeur vide requis pour la désérialisation
        public Menuchoices()
        {
        }

        public Menuchoices(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
