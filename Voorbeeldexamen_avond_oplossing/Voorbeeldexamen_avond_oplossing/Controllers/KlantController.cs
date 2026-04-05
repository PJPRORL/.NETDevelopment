using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TandartsPraktijkAPI.Dto.Afspraken;

namespace TandartsPraktijkAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KlantController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public KlantController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Alle klanten met hun afspraken ophalen")]
        public async Task<ActionResult<List<LijstKlantenMetAfspraakDto>>> KlantenOphalenMetAfspraken()
        {
            var klanten = await _context.KlantRepository.GetAllKlantenMetAfspraken();
            if( klanten == null )
            {
                return NotFound("Er zijn geen klanten gevonden");
            }
            List<LijstKlantenMetAfspraakDto> klantenDto = _mapper.Map<List<LijstKlantenMetAfspraakDto>>( klanten );
            return Ok(klantenDto);
        }

        [Authorize(Roles ="Tandarts")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKlant(int id)
        {
            var klant = await _context.KlantRepository.GetByIdAsync(id);
            if (klant == null)
            {
                return NotFound($"Geen klant gevonden met ID {id}");
            }

           var afsprakenKlant = await _context.AfspraakRepository.GetAfsprakenVanKlant(id);

           foreach(var afspraak in afsprakenKlant)
            {
                _context.AfspraakRepository.Delete(afspraak);
            } 

            // Verwijder de afspraak
            _context.KlantRepository.Delete(klant);

            // Sla de veranderingen op in de database
            await _context.SaveChangesAsync();

            return NoContent(); // Return 204 No Content na succesvolle verwijdering
        }

    }
}
