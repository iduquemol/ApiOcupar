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

        public async Task<IEnumerable<CatalogItem>> GetSucursalesAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_sucursalId",
                new { cod_suc = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapSucursales(json);
        }

        public async Task<IEnumerable<CatalogItem>> GetCentrosCostoAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_cCostoId",
                new { cod_cco = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapCentrosCosto(json);
        }

        public async Task<IEnumerable<CiudadItem>> GetCiudadesAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_ciudadId",
                new { cod_ciu = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapCiudades(json);
        }

        public async Task<IEnumerable<CatalogItem>> GetClasificador1Async()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_clasif1Id",
                new { cod_cl1 = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapClasificador1(json);
        }

        public async Task<IEnumerable<CatalogItem>> GetClasificador2Async()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_clasif2Id",
                new { cod_cl2 = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapClasificador2(json);
        }

        public async Task<IEnumerable<CatalogItem>> GetClasificador3Async()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_clasif3Id",
                new { cod_cl3 = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapClasificador3(json);
        }

        public async Task<IEnumerable<RetencionItem>> GetRetencionesAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_retencionId",
                new { cod_ret = (string?)null },
                commandType: CommandType.StoredProcedure);

            return MapRetenciones(json);
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

        internal static IEnumerable<CatalogItem> MapSucursales(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CatalogItem>();
            }

            var raw = JsonSerializer.Deserialize<List<SucursalJson>>(json, JsonOptions)
                ?? new List<SucursalJson>();

            return raw.Select(r => new CatalogItem { Codigo = r.CodSuc, Nombre = r.NomSuc });
        }

        internal static IEnumerable<CatalogItem> MapCentrosCosto(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CatalogItem>();
            }

            var raw = JsonSerializer.Deserialize<List<CCostoJson>>(json, JsonOptions)
                ?? new List<CCostoJson>();

            return raw.Select(r => new CatalogItem { Codigo = r.CodCco, Nombre = r.NomCco });
        }

        internal static IEnumerable<CiudadItem> MapCiudades(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CiudadItem>();
            }

            var raw = JsonSerializer.Deserialize<List<CiudadJson>>(json, JsonOptions)
                ?? new List<CiudadJson>();

            return raw.Select(r => new CiudadItem
            {
                Codigo = r.CodCiu,
                Nombre = r.NomCiu,
                CodigoDepartamento = r.CodDep,
                CodigoPais = r.CodPai
            });
        }

        internal static IEnumerable<CatalogItem> MapClasificador1(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CatalogItem>();
            }

            var raw = JsonSerializer.Deserialize<List<Clasif1Json>>(json, JsonOptions)
                ?? new List<Clasif1Json>();

            return raw.Select(r => new CatalogItem { Codigo = r.CodCl1, Nombre = r.NomCl1 });
        }

        internal static IEnumerable<CatalogItem> MapClasificador2(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CatalogItem>();
            }

            var raw = JsonSerializer.Deserialize<List<Clasif2Json>>(json, JsonOptions)
                ?? new List<Clasif2Json>();

            return raw.Select(r => new CatalogItem { Codigo = r.CodCl2, Nombre = r.NomCl2 });
        }

        internal static IEnumerable<CatalogItem> MapClasificador3(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CatalogItem>();
            }

            var raw = JsonSerializer.Deserialize<List<Clasif3Json>>(json, JsonOptions)
                ?? new List<Clasif3Json>();

            return raw.Select(r => new CatalogItem { Codigo = r.CodCl3, Nombre = r.NomCl3 });
        }

        internal static IEnumerable<RetencionItem> MapRetenciones(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<RetencionItem>();
            }

            var raw = JsonSerializer.Deserialize<List<RetencionJson>>(json, JsonOptions)
                ?? new List<RetencionJson>();

            return raw.Select(r => new RetencionItem
            {
                Codigo = r.CodRet,
                Nombre = r.Nombre,
                Porcentaje = r.PorRet,
                CuentaContable = r.CtaRet,
                NombreCuenta = r.NomCta
            });
        }
    }
}
