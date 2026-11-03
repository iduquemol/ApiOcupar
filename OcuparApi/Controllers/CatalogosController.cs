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

        [HttpGet("sucursales")]
        public async Task<IActionResult> GetSucursales()
        {
            var result = await _catalogosRepository.GetSucursalesAsync();
            return Ok(result);
        }

        [HttpGet("centros-costo")]
        public async Task<IActionResult> GetCentrosCosto()
        {
            var result = await _catalogosRepository.GetCentrosCostoAsync();
            return Ok(result);
        }

        [HttpGet("ciudades")]
        public async Task<IActionResult> GetCiudades()
        {
            var result = await _catalogosRepository.GetCiudadesAsync();
            return Ok(result);
        }

        [HttpGet("clasificador1")]
        public async Task<IActionResult> GetClasificador1()
        {
            var result = await _catalogosRepository.GetClasificador1Async();
            return Ok(result);
        }

        [HttpGet("clasificador2")]
        public async Task<IActionResult> GetClasificador2()
        {
            var result = await _catalogosRepository.GetClasificador2Async();
            return Ok(result);
        }

        [HttpGet("clasificador3")]
        public async Task<IActionResult> GetClasificador3()
        {
            var result = await _catalogosRepository.GetClasificador3Async();
            return Ok(result);
        }

        [HttpGet("retenciones")]
        public async Task<IActionResult> GetRetenciones()
        {
            var result = await _catalogosRepository.GetRetencionesAsync();
            return Ok(result);
        }
    }
}
