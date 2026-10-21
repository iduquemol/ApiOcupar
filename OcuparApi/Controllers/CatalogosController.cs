using Microsoft.AspNetCore.Mvc;
using OcuparApi.Services;

namespace OcuparApi.Controllers
{
    [ApiController]
    [Route("catalogos")]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogosRepository _catalogosRepository;

        public CatalogosController(ICatalogosRepository catalogosRepository)
        {
            _catalogosRepository = catalogosRepository;
        }

        [HttpGet("terceros")]
        public async Task<IActionResult> GetTerceros()
        {
            var result = await _catalogosRepository.GetTercerosAsync();
            return Ok(result);
        }

        [HttpGet("cuentas-contables")]
        public async Task<IActionResult> GetCuentasContables()
        {
            var result = await _catalogosRepository.GetCuentasContablesAsync();
            return Ok(result);
        }

        [HttpGet("subtipos-documento")]
        public async Task<IActionResult> GetSubTiposDocumento()
        {
            var result = await _catalogosRepository.GetSubTiposDocumentoAsync();
            return Ok(result);
        }
    }
}
