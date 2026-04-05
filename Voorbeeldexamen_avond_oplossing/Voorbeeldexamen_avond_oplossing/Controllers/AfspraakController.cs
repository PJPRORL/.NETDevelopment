
using Microsoft.AspNetCore.Authorization;
using TandartsPraktijkAPI.Dto.Gebruiker;

namespace TandartsPraktijkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AfspraakController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<Gebruiker> _userManager;
        private readonly IMapper _mapper;

        public AfspraakController(IUnitOfWork unitOfWork, 
            UserManager<Gebruiker> userManager,
            IMapper mapper)
        {
            _context = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AfspraakDto>> GetAfspraak(int id)
        {
            var afspraak = await _context.AfspraakRepository.GetAfspraakMetIdAsync(id);

            if (afspraak == null)
            {
                return NotFound();
            }
            AfspraakDto dto = _mapper.Map<AfspraakDto>(afspraak);

            return dto;
        }

        [HttpGet("Beschikbare tandartsen")]
        public async Task<ActionResult<List<TandartsDto>>> GetBeschikbareGebruikersOpTijdstipAsync(DateTime tijdstip)
        {
            List<Gebruiker> beschikbareTandartsen = new List<Gebruiker>();

            DateTime eindTijdstip = tijdstip.AddMinutes(15);
            var tandartsen = await _userManager.Users.ToListAsync();

            var afspraken = await _context.AfspraakRepository.GetAllAsync();
            foreach (var tandarts in tandartsen)
            {
                if(await _userManager.IsInRoleAsync(tandarts,"Tandarts"))
                {
                    var beschikbareAfspraken = afspraken.Where(x => x.DatumTijd >= tijdstip && x.DatumTijd<= eindTijdstip && x.GebruikerId == tandarts.Id).ToList();
                    if (beschikbareAfspraken.Count == 0)
                    {
                        beschikbareTandartsen.Add(tandarts);
                    }
                }
            }
            List<TandartsDto> tandartsDtos = _mapper.Map<List<TandartsDto>>(beschikbareTandartsen);
            return Ok(tandartsDtos);
        }

        [HttpPost("Nieuwe afspraak")]
        public async Task<ActionResult<Afspraak>> CreateAfspraak(CreateAfspraakDto dto)
        {
            // Check of de DTO valide is
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Controleer of de Gebruiker bestaat
            var gebruiker = await _userManager.FindByEmailAsync(dto.TandartsEmail);
            if (gebruiker == null)
            {
                return NotFound($"Geen tandarts gevonden met Email {dto.TandartsEmail}");
            }

            // Controleer of de Klant bestaat
            if (!await _context.KlantRepository.ExistsAsync(dto.KlantId))
            {
                return NotFound($"Geen klant gevonden met ID {dto.KlantId}");
            }

            // Controleer of de Behandeling bestaat
            if (!await _context.BehandelingRepository.ExistsAsync(dto.BehandelingId))
            {
                return NotFound($"Geen behandeling gevonden met ID {dto.BehandelingId}");
            }

            // Maak een nieuwe afspraak aan
            var nieuweAfspraak = _mapper.Map<Afspraak>(dto);
            nieuweAfspraak.GebruikerId = gebruiker.Id;

            // Voeg de nieuwe afspraak toe aan de context
            await _context.AfspraakRepository.AddAsync(nieuweAfspraak);

            // Sla de veranderingen op in de database
            await _context.SaveChangesAsync();

            // Return het resultaat
            return CreatedAtAction(nameof(GetAfspraak), new { id = nieuweAfspraak.Id }, nieuweAfspraak);
        }

        [HttpPut("Afspraak wijzigen {id}")]
        public async Task<ActionResult> UpdateAfspraak(int id, UpdateAfspraakDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Het ID in de route komt niet overeen met het ID in de body.");
            }

            // Check of de afspraak bestaat
            var afspraak = await _context.AfspraakRepository.GetAfspraakMetIdAsync(id);
            if (!await _context.AfspraakRepository.ExistsAsync(id))
            {
                return NotFound($"Geen afspraak gevonden met ID {id}");
            }

            // Controleer of de tandarts (gebruiker) bestaat
            var gebruiker = await _userManager.FindByEmailAsync(dto.TandartsEmail);
            if (gebruiker == null)
            {
                return NotFound($"Geen tandarts gevonden met Email {dto.TandartsEmail}");
            }

            // Controleer of de Klant bestaat
            if (!await _context.KlantRepository.ExistsAsync(dto.KlantId))
            {
                return NotFound($"Geen klant gevonden met ID {dto.KlantId}");
            }

            // Controleer of de Behandeling bestaat
            if (!await _context.BehandelingRepository.ExistsAsync(dto.BehandelingId))
            {
                return NotFound($"Geen behandeling gevonden met ID {dto.BehandelingId}");
            }

            // Update de afspraak
            _mapper.Map(dto, afspraak); // Dit update de entiteit met de waarden van de DTO
            afspraak.GebruikerId = gebruiker.Id;

            // Opslaan in de database
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content als de update succesvol was
        }

    }
}
