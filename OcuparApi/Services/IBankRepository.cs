using OcuparApi.Models;

namespace OcuparApi.Services
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetBanksAsync();
        Task<IEnumerable<BankAccount>> GetAccountsByBankAsync(string bankId);
    }
}
