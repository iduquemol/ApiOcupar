using OcuparApi.Models;

namespace OcuparApi.Services
{
    public interface IExtractoRepository
    {
        Task<int> LoadCajaSocialExtractoAsync(string cajaSocialJson);
        Task<IEnumerable<ExtractoMovement>> GetMovementsAsync(long idExtracto);
    }
}
