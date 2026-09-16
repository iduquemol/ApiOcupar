using OcuparApi.Models;
using Dapper;
using System.Data;
using System.Text.Json;

namespace OcuparApi.Services
{
    public class BankRepository : IBankRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly IDbConnectionFactory _connectionFactory;

        public BankRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Bank>> GetBanksAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            // usr_itq_Read_bancosId returns a single row with one JSON-text
            // column ("bancos"), not a relational rowset - same shape as
            // usr_sp_itq_consulta_fe in FacturasRepository.
            var bancos = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_bancosId",
                commandType: CommandType.StoredProcedure);

            return MapBanks(bancos);
        }

        public async Task<IEnumerable<BankAccount>> GetAccountsByBankAsync(string bankId)
        {
            using var connection = _connectionFactory.CreateConnection();

            // usr_itq_Read_cuentasbancosId returns a single row with one
            // JSON-text column ("cuentasBancos") listing every bank; only
            // the entry matching the @bancos input parameter has a non-null
            // nested account list.
            var cuentasBancos = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_cuentasbancosId",
                new { bancos = bankId },
                commandType: CommandType.StoredProcedure);

            return MapAccounts(cuentasBancos, bankId);
        }

        internal static IEnumerable<Bank> MapBanks(string? bancosJson)
        {
            if (string.IsNullOrWhiteSpace(bancosJson))
            {
                return Enumerable.Empty<Bank>();
            }

            var rawBanks = JsonSerializer.Deserialize<List<BankJson>>(bancosJson, JsonOptions)
                ?? new List<BankJson>();

            return rawBanks.Select(raw => new Bank
            {
                Id = raw.CodBan,
                Name = raw.NomBan
            });
        }

        internal static IEnumerable<BankAccount> MapAccounts(string? cuentasBancosJson, string bankId)
        {
            if (string.IsNullOrWhiteSpace(cuentasBancosJson))
            {
                return Enumerable.Empty<BankAccount>();
            }

            var entries = JsonSerializer.Deserialize<List<BankAccountsEntryJson>>(cuentasBancosJson, JsonOptions)
                ?? new List<BankAccountsEntryJson>();

            var matchedEntry = entries.FirstOrDefault(entry => entry.CodBan == bankId);
            if (matchedEntry?.CuentasBancos is null)
            {
                return Enumerable.Empty<BankAccount>();
            }

            return matchedEntry.CuentasBancos.Select(raw => new BankAccount
            {
                Id = raw.Ctabanco,
                BankId = bankId,
                Name = raw.Nombre,
                AccountNumber = raw.Ctabanco,
                TipoCuenta = raw.TipoCuenta
            });
        }
    }
}
