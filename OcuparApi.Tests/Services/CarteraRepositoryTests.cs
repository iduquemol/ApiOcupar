using Moq;
using OcuparApi.Services;

namespace OcuparApi.Tests.Services
{
    public class CarteraRepositoryTests
    {
        [Fact]
        public void MapCartera_WithMultipleEntries_MapsAllFieldsToCamelCase()
        {
            const string json = """
                [
                    {
                        "cod_cli": "79217534",
                        "nit_cli": "79217534",
                        "ano_doc": "2026",
                        "per_doc": "10",
                        "tip_doc": "010",
                        "sub_tip": "010",
                        "num_doc": "FES12870",
                        "reg_doc": 1,
                        "det_doc": " ARRENDAMIENTO ESPACIO CASA QUINTA CAMACHO",
                        "fec_ven": "2026-10-06",
                        "cod_suc": "04",
                        "cod_cco": "010000",
                        "cod_cl1": "00",
                        "cod_cl2": "04",
                        "cod_cl3": "0",
                        "ind_con": "0  ",
                        "sal_doc": 5408462.0,
                        "val_ret": 0.0,
                        "val_ica": 0.0,
                        "ret_iva": 0.0,
                        "may_val": 0.0,
                        "men_val": 0.0,
                        "valorPago": 0.0,
                        "cod_cta": "130505",
                        "tip_mon": "00",
                        "cod_pai": "057",
                        "cod_dep": "25",
                        "cod_ciu": "25000"
                    },
                    {
                        "cod_cli": "800053619",
                        "nit_cli": "800053619",
                        "ano_doc": "2026",
                        "per_doc": "09",
                        "tip_doc": "010",
                        "sub_tip": "010",
                        "num_doc": "FEP7683",
                        "reg_doc": 1,
                        "det_doc": "Servicio de colaboracion temporal",
                        "fec_ven": "2026-10-25",
                        "cod_suc": "05",
                        "cod_cco": "050199",
                        "cod_cl1": "00",
                        "cod_cl2": "06",
                        "cod_cl3": "0",
                        "ind_con": "0  ",
                        "sal_doc": 714714.0,
                        "val_ret": 0.0,
                        "val_ica": 0.0,
                        "ret_iva": 0.0,
                        "may_val": 0.0,
                        "men_val": 0.0,
                        "valorPago": 0.0,
                        "cod_cta": "130505",
                        "tip_mon": "00",
                        "cod_pai": "057",
                        "cod_dep": "66",
                        "cod_ciu": "66001"
                    }
                ]
                """;

            var result = CarteraRepository.MapCartera(json).ToList();

            Assert.Equal(2, result.Count);

            var first = result[0];
            Assert.Equal("79217534", first.CodigoCliente);
            Assert.Equal("79217534", first.NitCliente);
            Assert.Equal("2026", first.AnoDocumento);
            Assert.Equal("10", first.PeriodoDocumento);
            Assert.Equal("010", first.TipoDocumento);
            Assert.Equal("010", first.SubTipoDocumento);
            Assert.Equal("FES12870", first.NumeroDocumento);
            Assert.Equal(1, first.RegistroDocumento);
            Assert.Equal(" ARRENDAMIENTO ESPACIO CASA QUINTA CAMACHO", first.DetalleDocumento);
            Assert.Equal("2026-10-06", first.FechaVencimiento);
            Assert.Equal("04", first.CodigoSucursal);
            Assert.Equal("010000", first.CodigoCentroCosto);
            Assert.Equal("00", first.CodigoClasificador1);
            Assert.Equal("04", first.CodigoClasificador2);
            Assert.Equal("0", first.CodigoClasificador3);
            Assert.Equal("0  ", first.IndicadorConciliacion);
            Assert.Equal(5408462.0m, first.SaldoDocumento);
            Assert.Equal(0.0m, first.ValorRetencion);
            Assert.Equal(0.0m, first.ValorIca);
            Assert.Equal(0.0m, first.RetencionIva);
            Assert.Equal(0.0m, first.MayorValor);
            Assert.Equal(0.0m, first.MenorValor);
            Assert.Equal(0.0m, first.ValorPago);
            Assert.Equal("130505", first.CodigoCuentaContable);
            Assert.Equal("00", first.TipoMoneda);
            Assert.Equal("057", first.CodigoPais);
            Assert.Equal("25", first.CodigoDepartamento);
            Assert.Equal("25000", first.CodigoCiudad);

            Assert.Equal("800053619", result[1].CodigoCliente);
            Assert.Equal("66001", result[1].CodigoCiudad);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapCartera_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CarteraRepository.MapCartera(json));
        }

        [Fact]
        public async Task GetCarteraAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CarteraRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetCarteraAsync("79217534"));
        }
    }
}
