using Dapper;
using OcuparApi.Models;
using System.Data;
using System.Text.Json;

namespace OcuparApi.Services
{
    public class CatalogosRepository : ICatalogosRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly IDbConnectionFactory _connectionFactory;

        public CatalogosRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<CatalogItem>> GetTercerosAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_tercerosId",
                new { ter_nit = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapTerceros(json);
        }

        public async Task<IEnumerable<CatalogItem>> GetCuentasContablesAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_cuentasContablesId",
                new { cod_cta = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapCuentasContables(json);
        }

        public async Task<IEnumerable<CatalogItem>> GetSubTiposDocumentoAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_subTiposDocId",
                new { cod_sub = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapSubTiposDocumento(json);
        }

        internal static IEnumerable<CatalogItem> MapTerceros(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CatalogItem>();
            }

            var raw = JsonSerializer.Deserialize<List<TerceroJson>>(json, JsonOptions)
                ?? new List<TerceroJson>();

            return raw.Select(r => new CatalogItem { Codigo = r.TerNit, Nombre = r.TerNombre });
        }

        internal static IEnumerable<CatalogItem> MapCuentasContables(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CatalogItem>();
            }

            var raw = JsonSerializer.Deserialize<List<CuentaContableJson>>(json, JsonOptions)
                ?? new List<CuentaContableJson>();

            return raw.Select(r => new CatalogItem { Codigo = r.CodCta, Nombre = r.NomCta });
        }

        internal static IEnumerable<CatalogItem> MapSubTiposDocumento(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CatalogItem>();
            }

            var raw = JsonSerializer.Deserialize<List<SubTipoDocumentoJson>>(json, JsonOptions)
                ?? new List<SubTipoDocumentoJson>();

            return raw.Select(r => new CatalogItem { Codigo = r.CodSub, Nombre = r.NomSub });
        }
    }
}
