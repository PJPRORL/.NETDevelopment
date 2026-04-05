namespace TandartsPraktijkAPI.Dto
{
    public class GebruikerRegistratieDto
    {

        [Required(ErrorMessage = "Voornaam is verplicht.")]
        [MaxLength(50, ErrorMessage = "Voornaam mag niet meer dan 50 tekens bevatten.")]
        public string Voornaam { get; set; }


        [Required(ErrorMessage = "Naam is benodigd!")]
        [StringLength(100)]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Adres is verplicht.")]
        [MaxLength(100, ErrorMessage = "Adres mag niet meer dan 100 tekens bevatten.")]
        public string Adres { get; set; }

        [EmailAddress(ErrorMessage = "Ongeldig emailadres")]
        [Required(ErrorMessage = "Email is verplicht!")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is verplicht!")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Tweede wachtwoord is verplicht in te vullen.")]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; set; } = "";

        public string PhoneNumber { get; set; } = "";
    }
}
