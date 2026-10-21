namespace OcuparApi.Models
{
    public record CatalogItem
    {
        public string Codigo { get; init; } = string.Empty;
        public string Nombre { get; init; } = string.Empty;
    }
}
