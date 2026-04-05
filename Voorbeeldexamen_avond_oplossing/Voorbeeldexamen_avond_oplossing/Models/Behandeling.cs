using System.ComponentModel.DataAnnotations.Schema;

namespace TandartsPraktijkAPI.Models
{
    public class Behandeling
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "De naam van de behandeling is verplicht.")]
        [MaxLength(100, ErrorMessage = "De naam van de behandeling mag niet meer dan 100 tekens bevatten.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "De prijs van de behandeling is verplicht.")]
        [Range(0, 10000, ErrorMessage = "De prijs moet tussen 0 en 10.000 euro liggen.")]
        public decimal Prijs { get; set; }

        [MaxLength(1000, ErrorMessage = "De beschrijving mag niet meer dan 1000 tekens bevatten.")]
        public string Beschrijving { get; set; }

        public ICollection<Afspraak>? Afspraken { get; set; }
    }
}
