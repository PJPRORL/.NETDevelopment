namespace TandartsPraktijkAPI.Dto.Afspraken
{
    public class LijstKlantenMetAfspraakDto
    {
        public string NaamKlant {  get; set; }
        public List <AfspraakBasicDto> Afspraken{ get; set; }
    }
}
