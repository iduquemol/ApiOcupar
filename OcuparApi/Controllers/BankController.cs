using Microsoft.AspNetCore.Mvc;
using OcuparApi.Services;

namespace OcuparApi.Controllers
{
    [ApiController]
    [Route("banks")]
    public class BankController : ControllerBase
    {
        private readonly IBankRepository _bankRepository;

        public BankController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var banks = await _bankRepository.GetBanksAsync();
            return Ok(banks);
        }

        [HttpGet("{bankId}/accounts")]
        public async Task<IActionResult> GetAccounts(string bankId)
        {
            var accounts = await _bankRepository.GetAccountsByBankAsync(bankId);
            return Ok(accounts);
        }
    }
}
