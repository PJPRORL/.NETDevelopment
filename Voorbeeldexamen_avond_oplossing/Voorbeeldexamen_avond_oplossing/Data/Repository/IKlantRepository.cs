namespace TandartsPraktijkAPI.Data.Repository
{
    public interface IKlantRepository:IGenericRepository<Klant>
    {
        Task<IEnumerable<Klant>> GetAllKlantenMetAfspraken();
    }
}
