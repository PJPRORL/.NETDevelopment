
namespace TandartsPraktijkAPI.Data.Repository
{
    public class KlantRepository : GenericRepository<Klant>, IKlantRepository
    {
        public KlantRepository(APIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Klant>> GetAllKlantenMetAfspraken()
        {
            return await _context.Set<Klant>()
                .Include(x=>x.Afspraken)
                .ThenInclude(x=>x.Gebruiker)
                .Include(x=>x.Afspraken)
                .ThenInclude(x=>x.Behandeling).ToListAsync();
        }


    }
}
