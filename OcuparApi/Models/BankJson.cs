using System.Text.Json.Serialization;

namespace OcuparApi.Models
{
    /// <summary>
    /// Raw shape of one element in the JSON array returned by
    /// usr_itq_Read_bancosId's single "bancos" column.
    /// BankRepository maps this to the public Bank record.
    /// </summary>
    internal record BankJson
    {
        [JsonPropertyName("cod_ban")]
        public string CodBan { get; init; } = string.Empty;

        [JsonPropertyName("nom_ban")]
        public string NomBan { get; init; } = string.Empty;
    }
}
