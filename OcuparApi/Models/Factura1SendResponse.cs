using System.Text.Json.Serialization;
using OcuparApi.Serialization;

namespace OcuparApi.Models
{
    public class Factura1SendResponse
    {
        [JsonPropertyName("qrdata")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Qrdata { get; set; }

        [JsonPropertyName("DIAN")]
        public List<Factura1DianResult>? DIAN { get; set; }

        [JsonPropertyName("xml")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Xml { get; set; }

        [JsonPropertyName("clavtec")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Clavtec { get; set; }

        [JsonPropertyName("id")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Id { get; set; }

        [JsonPropertyName("error")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Error { get; set; }

        [JsonPropertyName("cufe")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Cufe { get; set; }
    }

    public class Factura1DianResult
    {
        [JsonPropertyName("Mensaje")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Mensaje { get; set; }

        [JsonPropertyName("Xml")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Xml { get; set; }

        [JsonPropertyName("Valido")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Valido { get; set; }

        [JsonPropertyName("Descripcion")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Descripcion { get; set; }

        [JsonPropertyName("StatusCode")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? StatusCode { get; set; }

        [JsonPropertyName("Respuesta")]
        public List<Factura1DianRespuesta>? Respuesta { get; set; }
    }

    public class Factura1DianRespuesta
    {
        [JsonPropertyName("descripcion")]
        [JsonConverter(typeof(LenientStringJsonConverter))]
        public string? Descripcion { get; set; }
    }
}
