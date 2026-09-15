using OcuparApi.Models;

namespace OcuparApi.Services
{
    public interface IFacturasRepository
    {
        Task<IEnumerable<FacturaRecord>> GetFacturasAsync(DateOnly fechaIni, DateOnly fechaFin);
        Task<string?> GenerarFacturaXmlAsync(string folio);
    }
}
