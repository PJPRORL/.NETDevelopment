
namespace TandartsPraktijkAPI.Data.Repository
{
    public class AfspraakRepository : GenericRepository<Afspraak>, IAfspraakRepository
    {
        public AfspraakRepository(APIDbContext context) : base(context)
        {
        }

        public async Task<Afspraak> GetAfspraakMetIdAsync(int id)
        {
            return await _context.Afspraken.Include(x => x.Klant).Include(x => x.Gebruiker).Include(x => x.Behandeling).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<List<Afspraak>> GetAfsprakenMetDatumAsync(DateTime? tijdstip)
        {
            if (tijdstip == null)
            {
                return await _context.Afspraken.Include(x => x.Klant).Include(x => x.Gebruiker).Include(x => x.Behandeling).ToListAsync();
            }
            else
            {
                return await _context.Afspraken.Where(x => x.DatumTijd.Date == tijdstip)
                    .Include(x => x.Klant)
                    .Include(x => x.Gebruiker)
                    .Include(x => x.Behandeling)
                    .ToListAsync();
            }

        }

        public Task<List<Afspraak>> GetAfsprakenVanKlant(int id)
        {
            return _context.Afspraken.Where(x=>x.KlantId == id).ToListAsync();
        }
    }
}
