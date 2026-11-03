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

    internal record SucursalJson
    {
        [JsonPropertyName("cod_suc")]
        public string CodSuc { get; init; } = string.Empty;

        [JsonPropertyName("nom_suc")]
        public string NomSuc { get; init; } = string.Empty;
    }

    internal record CCostoJson
    {
        [JsonPropertyName("cod_cco")]
        public string CodCco { get; init; } = string.Empty;

        [JsonPropertyName("nom_cco")]
        public string NomCco { get; init; } = string.Empty;
    }

    internal record CiudadJson
    {
        [JsonPropertyName("cod_ciu")]
        public string CodCiu { get; init; } = string.Empty;

        [JsonPropertyName("cod_dep")]
        public string CodDep { get; init; } = string.Empty;

        [JsonPropertyName("cod_pai")]
        public string CodPai { get; init; } = string.Empty;

        [JsonPropertyName("nom_ciu")]
        public string NomCiu { get; init; } = string.Empty;
    }

    internal record Clasif1Json
    {
        [JsonPropertyName("cod_cl1")]
        public string CodCl1 { get; init; } = string.Empty;

        [JsonPropertyName("nom_cl1")]
        public string NomCl1 { get; init; } = string.Empty;
    }

    internal record Clasif2Json
    {
        [JsonPropertyName("cod_cl2")]
        public string CodCl2 { get; init; } = string.Empty;

        [JsonPropertyName("nom_cl2")]
        public string NomCl2 { get; init; } = string.Empty;
    }

    internal record Clasif3Json
    {
        [JsonPropertyName("cod_cl3")]
        public string CodCl3 { get; init; } = string.Empty;

        [JsonPropertyName("nom_cl3")]
        public string NomCl3 { get; init; } = string.Empty;
    }

    internal record RetencionJson
    {
        [JsonPropertyName("cod_ret")]
        public string CodRet { get; init; } = string.Empty;

        [JsonPropertyName("nombre")]
        public string Nombre { get; init; } = string.Empty;

        [JsonPropertyName("por_ret")]
        public decimal PorRet { get; init; }

        [JsonPropertyName("cta_ret")]
        public string CtaRet { get; init; } = string.Empty;

        [JsonPropertyName("nom_cta")]
        public string NomCta { get; init; } = string.Empty;
    }
}
