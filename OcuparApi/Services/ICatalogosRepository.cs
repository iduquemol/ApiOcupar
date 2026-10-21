using OcuparApi.Models;

namespace OcuparApi.Services
{
    public interface ICatalogosRepository
    {
        Task<IEnumerable<CatalogItem>> GetTercerosAsync();
        Task<IEnumerable<CatalogItem>> GetCuentasContablesAsync();
        Task<IEnumerable<CatalogItem>> GetSubTiposDocumentoAsync();
    }
}
