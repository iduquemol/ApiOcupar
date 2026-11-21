using Microsoft.AspNetCore.Mvc;
using OcuparApi.Services;

namespace OcuparApi.Controllers
{
    [ApiController]
    [Route("cartera")]
    public class CarteraController : ControllerBase
    {
        private readonly ICarteraRepository _carteraRepository;

        public CarteraController(ICarteraRepository carteraRepository)
        {
            _carteraRepository = carteraRepository;
        }

        [HttpGet("{nitCli}")]
        public async Task<IActionResult> GetCartera(string nitCli)
        {
            var result = await _carteraRepository.GetCarteraAsync(nitCli);
            return Ok(result);
        }
    }
}
