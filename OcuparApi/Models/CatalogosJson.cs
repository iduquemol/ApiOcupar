using System.Text.Json.Serialization;

namespace OcuparApi.Models
{
    /// <summary>
    /// Raw shapes of the JSON arrays returned by the catalogos_* stored
    /// procedures' single JSON-text column. CatalogosRepository maps each
    /// to the shared public CatalogItem { Codigo, Nombre } record.
    /// </summary>
    internal record TerceroJson
    {
        [JsonPropertyName("ter_nit")]
        public string TerNit { get; init; } = string.Empty;

        [JsonPropertyName("ter_nombre")]
        public string TerNombre { get; init; } = string.Empty;
    }

    internal record CuentaContableJson
    {
        [JsonPropertyName("cod_cta")]
        public string CodCta { get; init; } = string.Empty;

        [JsonPropertyName("nom_cta")]
        public string NomCta { get; init; } = string.Empty;
    }

    internal record SubTipoDocumentoJson
    {
        [JsonPropertyName("cod_sub")]
        public string CodSub { get; init; } = string.Empty;

        [JsonPropertyName("nom_sub")]
        public string NomSub { get; init; } = string.Empty;
    }
}
