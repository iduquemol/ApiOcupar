using System.Text.Json.Serialization;

namespace OcuparApi.Models
{
    /// <summary>
    /// Raw shape of one element in the JSON array returned by
    /// usr_itq_Read_cuentasbancosId's single "cuentasBancos" column: one
    /// entry per bank, with cuentasBancos null unless it's the bank that
    /// matches the stored procedure's input parameter.
    /// BankRepository maps the matching entry's nested accounts to BankAccount.
    /// </summary>
    internal record BankAccountsEntryJson
    {
        [JsonPropertyName("cod_ban")]
        public string CodBan { get; init; } = string.Empty;

        [JsonPropertyName("nom_ban")]
        public string NomBan { get; init; } = string.Empty;

        public List<BankAccountJson>? CuentasBancos { get; init; }
    }

    /// <summary>
    /// Raw shape of one nested account entry. The "bancos" field is not
    /// reliably the parent entry's bank code (per sample data) and is not
    /// used as the account's BankId - see design.md.
    /// </summary>
    internal record BankAccountJson
    {
        public string Bancos { get; init; } = string.Empty;
        public string Nombre { get; init; } = string.Empty;
        public string Ctabanco { get; init; } = string.Empty;
        public string TipoCuenta { get; init; } = string.Empty;
    }
}
