namespace TandartsPraktijkAPI.Models
{
    public class Gebruiker: IdentityUser
    {
        [Required(ErrorMessage = "Voornaam is verplicht.")]
        [MaxLength(50, ErrorMessage = "Voornaam mag niet meer dan 50 tekens bevatten.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht.")]
        [MaxLength(50, ErrorMessage = "Achternaam mag niet meer dan 50 tekens bevatten.")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Adres is verplicht.")]
        [MaxLength(100, ErrorMessage = "Adres mag niet meer dan 100 tekens bevatten.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Telefoonnummer is verplicht.")]
        [MaxLength(15, ErrorMessage = "Telefoonnummer mag niet meer dan 15 tekens bevatten.")]
        public string Telefoonnummer { get; set; }

        [Required(ErrorMessage = "Specialisatie is verplicht.")]
        [MaxLength(100, ErrorMessage = "Specialisatie mag niet meer dan 100 tekens bevatten.")]
        public string Specialisatie { get; set; }

        [Required(ErrorMessage = "Licentie is verplicht.")]
        [MaxLength(50, ErrorMessage = "Licentie mag niet meer dan 50 tekens bevatten.")]
        public string Licentie { get; set; }

        public List<Afspraak>? Afspraken { get; set; }

    }
}
