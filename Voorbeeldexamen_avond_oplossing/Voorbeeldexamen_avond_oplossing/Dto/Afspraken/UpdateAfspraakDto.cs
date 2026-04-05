namespace TandartsPraktijkAPI.Dto
{
    public class UpdateAfspraakDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "De datum en tijd van de afspraak is verplicht.")]
        public DateTime DatumTijd { get; set; }

        [MaxLength(500, ErrorMessage = "Opmerkingen mogen niet meer dan 500 tekens bevatten.")]
        public string Opmerkingen { get; set; }

        [Required(ErrorMessage = "De tandarts is verplicht voor de afspraak.")]
        public string TandartsEmail { get; set; }

        [Required(ErrorMessage = "De klant is verplicht voor de afspraak.")]
        public int KlantId { get; set; }

        [Required(ErrorMessage = "De behandeling is verplicht voor de afspraak.")]
        public int BehandelingId { get; set; }
    }

}
