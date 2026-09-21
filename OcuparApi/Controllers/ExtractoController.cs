using Microsoft.AspNetCore.Mvc;
using OcuparApi.Models;
using OcuparApi.Services;
using System.Text.Json;

namespace OcuparApi.Controllers
{
    [ApiController]
    [Route("extractos")]
    public class ExtractoController : ControllerBase
    {
        private readonly IExtractoRepository _extractoRepository;

        public ExtractoController(IExtractoRepository extractoRepository)
        {
            _extractoRepository = extractoRepository;
        }

        [HttpPost("caja-social")]
        [Consumes("application/json")]
        public async Task<IActionResult> PostCajaSocial([FromBody] JsonElement body)
        {
            var idExtracto = await _extractoRepository.LoadCajaSocialExtractoAsync(body.GetRawText());
            return Ok(new LoadExtractoResult { IdExtracto = idExtracto });
        }
    }
}
