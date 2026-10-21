namespace OcuparApi.Models
{
    public record ExtractoMovement
    {
        public long IdRegistroExtracto { get; init; }
        public long IdExtracto { get; init; }
        public string FechaMovimiento { get; init; } = string.Empty;
        public string? DescripcionMovimiento { get; init; }
        public string? DetalleMovimiento { get; init; }
        public decimal Debito { get; init; }
        public decimal Credito { get; init; }
        public string? NitTercero { get; init; }
        public string? NombreTercero { get; init; }
        public string? TipoMovimiento { get; init; }
        public string? SubTipoDocumento { get; init; }
        public string? CuentaContable { get; init; }
    }
}
