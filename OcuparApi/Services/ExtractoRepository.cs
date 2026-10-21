using Dapper;
using OcuparApi.Models;
using System.Data;
using System.Text.Json;

namespace OcuparApi.Services
{
    public class ExtractoRepository : IExtractoRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly IDbConnectionFactory _connectionFactory;

        public ExtractoRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> LoadCajaSocialExtractoAsync(string cajaSocialJson)
        {
            using var connection = _connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("cajaSocial", cajaSocialJson, DbType.String, size: -1);
            parameters.Add("idExtracto", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await connection.ExecuteAsync(
                "usr_sp_itq_CargaExtractoCajaSocial",
                parameters,
                commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("idExtracto");
        }

        public async Task<IEnumerable<ExtractoMovement>> GetMovementsAsync(long idExtracto)
        {
            using var connection = _connectionFactory.CreateConnection();

            // usr_itq_Read_ExtractoId returns a single row with one JSON-text
            // column ("bancos", despite containing movement rows) - same
            // shape as usr_itq_Read_bancosId.
            var bancos = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_ExtractoId",
                new { idExtracto },
                commandType: CommandType.StoredProcedure);

            return MapMovements(bancos);
        }

        internal static IEnumerable<ExtractoMovement> MapMovements(string? bancosJson)
        {
            if (string.IsNullOrWhiteSpace(bancosJson))
            {
                return Enumerable.Empty<ExtractoMovement>();
            }

            var rawMovements = JsonSerializer.Deserialize<List<ExtractoMovementJson>>(bancosJson, JsonOptions)
                ?? new List<ExtractoMovementJson>();

            return rawMovements.Select(raw => new ExtractoMovement
            {
                IdRegistroExtracto = raw.IdRegistroExtracto,
                IdExtracto = raw.IdExtracto,
                FechaMovimiento = raw.FechaMovimiento,
                DescripcionMovimiento = raw.DescripcionMovimiento,
                DetalleMovimiento = raw.DetalleMovimiento,
                Debito = raw.Debito,
                Credito = raw.Credito,
                NitTercero = raw.NitTercero,
                NombreTercero = raw.NombreTercero,
                TipoMovimiento = raw.TipoMovimiento,
                SubTipoDocumento = raw.SubTipoDocumento,
                CuentaContable = raw.CuentaContable
            });
        }
    }
}
