using OcuparApi.Models;

namespace OcuparApi.Services
{
    public interface ICatalogosRepository
    {
        Task<IEnumerable<CatalogItem>> GetTercerosAsync();
        Task<IEnumerable<CatalogItem>> GetCuentasContablesAsync();
        Task<IEnumerable<CatalogItem>> GetSubTiposDocumentoAsync();
        Task<IEnumerable<CatalogItem>> GetSucursalesAsync();
        Task<IEnumerable<CatalogItem>> GetCentrosCostoAsync();
        Task<IEnumerable<CiudadItem>> GetCiudadesAsync();
        Task<IEnumerable<CatalogItem>> GetClasificador1Async();
        Task<IEnumerable<CatalogItem>> GetClasificador2Async();
        Task<IEnumerable<CatalogItem>> GetClasificador3Async();
        Task<IEnumerable<RetencionItem>> GetRetencionesAsync();
    }
}
