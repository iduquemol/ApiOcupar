using Dapper;
using OcuparApi.Models;
using System.Data;
using System.Text.Json;

namespace OcuparApi.Services
{
    public class CarteraRepository : ICarteraRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly IDbConnectionFactory _connectionFactory;

        public CarteraRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<CarteraDocumento>> GetCarteraAsync(string nitCli)
        {
            using var connection = _connectionFactory.CreateConnection();

            var json = await connection.QuerySingleOrDefaultAsync<string?>(
                "usr_itq_Read_carteraId",
                new { nit_cli = nitCli },
                commandType: CommandType.StoredProcedure);

            return MapCartera(json);
        }

        internal static IEnumerable<CarteraDocumento> MapCartera(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return Enumerable.Empty<CarteraDocumento>();
            }

            var raw = JsonSerializer.Deserialize<List<CarteraDocumentoJson>>(json, JsonOptions)
                ?? new List<CarteraDocumentoJson>();

            return raw.Select(r => new CarteraDocumento
            {
                CodigoCliente = r.CodCli,
                NitCliente = r.NitCli,
                AnoDocumento = r.AnoDoc,
                PeriodoDocumento = r.PerDoc,
                TipoDocumento = r.TipDoc,
                SubTipoDocumento = r.SubTip,
                NumeroDocumento = r.NumDoc,
                RegistroDocumento = r.RegDoc,
                DetalleDocumento = r.DetDoc,
                FechaVencimiento = r.FecVen,
                CodigoSucursal = r.CodSuc,
                CodigoCentroCosto = r.CodCco,
                CodigoClasificador1 = r.CodCl1,
                CodigoClasificador2 = r.CodCl2,
                CodigoClasificador3 = r.CodCl3,
                IndicadorConciliacion = r.IndCon,
                SaldoDocumento = r.SalDoc,
                ValorRetencion = r.ValRet,
                ValorIca = r.ValIca,
                RetencionIva = r.RetIva,
                MayorValor = r.MayVal,
                MenorValor = r.MenVal,
                ValorPago = r.ValorPago,
                CodigoCuentaContable = r.CodCta,
                TipoMoneda = r.TipMon,
                CodigoPais = r.CodPai,
                CodigoDepartamento = r.CodDep,
                CodigoCiudad = r.CodCiu
            });
        }
    }
}
