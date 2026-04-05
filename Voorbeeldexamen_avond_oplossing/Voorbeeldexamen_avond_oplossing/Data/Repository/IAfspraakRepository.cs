namespace TandartsPraktijkAPI.Data.Repository
{
    public interface IAfspraakRepository: IGenericRepository<Afspraak>
    {
        Task<List<Afspraak>> GetAfsprakenMetDatumAsync(DateTime? tijdstip);
        Task<Afspraak> GetAfspraakMetIdAsync(int id);

        Task<List<Afspraak>> GetAfsprakenVanKlant(int id);
    }
}
