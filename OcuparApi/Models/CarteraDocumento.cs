namespace OcuparApi.Models
{
    public record CarteraDocumento
    {
        public string CodigoCliente { get; init; } = string.Empty;
        public string NitCliente { get; init; } = string.Empty;
        public string AnoDocumento { get; init; } = string.Empty;
        public string PeriodoDocumento { get; init; } = string.Empty;
        public string TipoDocumento { get; init; } = string.Empty;
        public string SubTipoDocumento { get; init; } = string.Empty;
        public string NumeroDocumento { get; init; } = string.Empty;
        public int RegistroDocumento { get; init; }
        public string? DetalleDocumento { get; init; }
        public string FechaVencimiento { get; init; } = string.Empty;
        public string CodigoSucursal { get; init; } = string.Empty;
        public string CodigoCentroCosto { get; init; } = string.Empty;
        public string CodigoClasificador1 { get; init; } = string.Empty;
        public string CodigoClasificador2 { get; init; } = string.Empty;
        public string CodigoClasificador3 { get; init; } = string.Empty;
        public string IndicadorConciliacion { get; init; } = string.Empty;
        public decimal SaldoDocumento { get; init; }
        public decimal ValorRetencion { get; init; }
        public decimal ValorIca { get; init; }
        public decimal RetencionIva { get; init; }
        public decimal MayorValor { get; init; }
        public decimal MenorValor { get; init; }
        public decimal ValorPago { get; init; }
        public string CodigoCuentaContable { get; init; } = string.Empty;
        public string TipoMoneda { get; init; } = string.Empty;
        public string CodigoPais { get; init; } = string.Empty;
        public string CodigoDepartamento { get; init; } = string.Empty;
        public string CodigoCiudad { get; init; } = string.Empty;
    }
}
