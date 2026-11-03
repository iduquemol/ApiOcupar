namespace OcuparApi.Models
{
    public record CatalogItem
    {
        public string Codigo { get; init; } = string.Empty;
        public string Nombre { get; init; } = string.Empty;
    }

    public record CiudadItem
    {
        public string Codigo { get; init; } = string.Empty;
        public string Nombre { get; init; } = string.Empty;
        public string CodigoDepartamento { get; init; } = string.Empty;
        public string CodigoPais { get; init; } = string.Empty;
    }

    public record RetencionItem
    {
        public string Codigo { get; init; } = string.Empty;
        public string Nombre { get; init; } = string.Empty;
        public decimal Porcentaje { get; init; }
        public string CuentaContable { get; init; } = string.Empty;
        public string NombreCuenta { get; init; } = string.Empty;
    }
}
