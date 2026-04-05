using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace TandartsPraktijkAPI.Models
{
    public class Afspraak
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "De datum en tijd van de afspraak is verplicht.")]
        public DateTime DatumTijd { get; set; }

        [MaxLength(500, ErrorMessage = "Opmerkingen mogen niet meer dan 500 tekens bevatten.")]
        public string Opmerkingen { get; set; }

        // Foreign Key naar Tandarts
        [Required(ErrorMessage = "De tandarts is verplicht voor de afspraak.")]
        public string GebruikerId { get; set; }

        public Gebruiker? Gebruiker { get; set; }

        // Foreign Key naar Gebruiker
        [Required(ErrorMessage = "De klant is verplicht voor de afspraak.")]
        public int KlantId { get; set; }
        public Klant? Klant { get; set; }

        // Foreign Key naar Behandeling
        [Required(ErrorMessage = "De behandeling is verplicht voor de afspraak.")]
        public int BehandelingId { get; set; }
        public Behandeling? Behandeling { get; set; }
    }
}
