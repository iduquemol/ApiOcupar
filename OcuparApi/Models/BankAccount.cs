namespace OcuparApi.Models
{
    public record BankAccount
    {
        public string Id { get; init; } = string.Empty;
        public string BankId { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string AccountNumber { get; init; } = string.Empty;
        public string TipoCuenta { get; init; } = string.Empty;
    }
}
