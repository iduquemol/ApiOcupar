using System.Text.Json.Serialization;

namespace OcuparApi.Models
{
    internal record CarteraDocumentoJson
    {
        [JsonPropertyName("cod_cli")]
        public string CodCli { get; init; } = string.Empty;

        [JsonPropertyName("nit_cli")]
        public string NitCli { get; init; } = string.Empty;

        [JsonPropertyName("ano_doc")]
        public string AnoDoc { get; init; } = string.Empty;

        [JsonPropertyName("per_doc")]
        public string PerDoc { get; init; } = string.Empty;

        [JsonPropertyName("tip_doc")]
        public string TipDoc { get; init; } = string.Empty;

        [JsonPropertyName("sub_tip")]
        public string SubTip { get; init; } = string.Empty;

        [JsonPropertyName("num_doc")]
        public string NumDoc { get; init; } = string.Empty;

        [JsonPropertyName("reg_doc")]
        public int RegDoc { get; init; }

        [JsonPropertyName("det_doc")]
        public string? DetDoc { get; init; }

        [JsonPropertyName("fec_ven")]
        public string FecVen { get; init; } = string.Empty;

        [JsonPropertyName("cod_suc")]
        public string CodSuc { get; init; } = string.Empty;

        [JsonPropertyName("cod_cco")]
        public string CodCco { get; init; } = string.Empty;

        [JsonPropertyName("cod_cl1")]
        public string CodCl1 { get; init; } = string.Empty;

        [JsonPropertyName("cod_cl2")]
        public string CodCl2 { get; init; } = string.Empty;

        [JsonPropertyName("cod_cl3")]
        public string CodCl3 { get; init; } = string.Empty;

        [JsonPropertyName("ind_con")]
        public string IndCon { get; init; } = string.Empty;

        [JsonPropertyName("sal_doc")]
        public decimal SalDoc { get; init; }

        [JsonPropertyName("val_ret")]
        public decimal ValRet { get; init; }

        [JsonPropertyName("val_ica")]
        public decimal ValIca { get; init; }

        [JsonPropertyName("ret_iva")]
        public decimal RetIva { get; init; }

        [JsonPropertyName("may_val")]
        public decimal MayVal { get; init; }

        [JsonPropertyName("men_val")]
        public decimal MenVal { get; init; }

        [JsonPropertyName("valorPago")]
        public decimal ValorPago { get; init; }

        [JsonPropertyName("cod_cta")]
        public string CodCta { get; init; } = string.Empty;

        [JsonPropertyName("tip_mon")]
        public string TipMon { get; init; } = string.Empty;

        [JsonPropertyName("cod_pai")]
        public string CodPai { get; init; } = string.Empty;

        [JsonPropertyName("cod_dep")]
        public string CodDep { get; init; } = string.Empty;

        [JsonPropertyName("cod_ciu")]
        public string CodCiu { get; init; } = string.Empty;
    }
}
