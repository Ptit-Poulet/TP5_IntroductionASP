namespace TP5_IntroASP.Models
{
    public class Menuchoices
    {
        public int Id { get; set; }
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
