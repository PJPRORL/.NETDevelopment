
using TandartsPraktijkAPI.Dto.Afspraken;
using TandartsPraktijkAPI.Dto.Gebruiker;

namespace TandartsPraktijkAPI.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
           CreateMap<Gebruiker, TandartsDto>()
               .ForMember(x=>x.Naam, opt=> opt.MapFrom(src=>$"{src.Voornaam} {src.Achternaam}"));

            CreateMap<Afspraak, AfspraakDto>()
                .ForMember(x => x.NaamTandarts, opt => opt.MapFrom(src => $"{src.Gebruiker.Voornaam} {src.Gebruiker.Achternaam}"))
                .ForMember(x => x.NaamKlant, opt => opt.MapFrom(src => $"{src.Klant.Voornaam} {src.Klant.Achternaam}"))
                .ForMember(x => x.Behandeling, opt => opt.MapFrom(src => src.Behandeling.Naam))
                .ForMember(x => x.Tijdstip, opt => opt.MapFrom(src => src.DatumTijd));

            CreateMap<CreateAfspraakDto, Afspraak>();

            CreateMap<UpdateAfspraakDto, Afspraak>();

            CreateMap<Afspraak, AfspraakBasicDto>()
                .ForMember(x => x.NaamTandarts, opt => opt.MapFrom(src => $"{src.Gebruiker.Voornaam} {src.Gebruiker.Achternaam}"))
                .ForMember(x => x.NaamBehandeling, opt => opt.MapFrom(src => src.Behandeling.Naam))
                .ForMember(x => x.DatumAfspraak, opt => opt.MapFrom(src => src.DatumTijd));

            CreateMap<Klant, LijstKlantenMetAfspraakDto>()
                .ForMember(x => x.NaamKlant, opt => opt.MapFrom(src => $"{src.Voornaam} {src.Achternaam}"));
        }
    }
}
