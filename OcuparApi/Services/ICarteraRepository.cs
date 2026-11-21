using OcuparApi.Models;

namespace OcuparApi.Services
{
    public interface ICarteraRepository
    {
        Task<IEnumerable<CarteraDocumento>> GetCarteraAsync(string nitCli);
    }
}
