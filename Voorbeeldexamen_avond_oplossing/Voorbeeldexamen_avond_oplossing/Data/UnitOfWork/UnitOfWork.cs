


using Microsoft.EntityFrameworkCore;

namespace TandartsPraktijkAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APIDbContext _context;
        private IAfspraakRepository _afspraakRepository;
        private IKlantRepository _klantRepository;
        private IGenericRepository<Behandeling> _behandelingRepository;

        public UnitOfWork(APIDbContext context)
        {
            _context = context;
        }

        public IAfspraakRepository AfspraakRepository => _afspraakRepository ??= new AfspraakRepository(_context);

        public IKlantRepository KlantRepository => _klantRepository ??= new KlantRepository(_context);

        public IGenericRepository<Behandeling> BehandelingRepository => _behandelingRepository ??= new GenericRepository<Behandeling>(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
