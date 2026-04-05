

namespace TandartsPraktijkAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAfspraakRepository AfspraakRepository { get; }
        IKlantRepository KlantRepository { get; }
        IGenericRepository<Behandeling> BehandelingRepository { get; }
        public Task SaveChangesAsync();
    }
}
