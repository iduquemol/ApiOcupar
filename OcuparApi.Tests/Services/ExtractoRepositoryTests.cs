using Moq;
using OcuparApi.Services;

namespace OcuparApi.Tests.Services
{
    public class ExtractoRepositoryTests
    {
        [Fact]
        public async Task LoadCajaSocialExtractoAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new ExtractoRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => repository.LoadCajaSocialExtractoAsync("{\"codigoBanco\":\"32\"}"));
        }

        [Fact]
        public void MapMovements_WithMultipleEntries_MapsAllFields()
        {
            const string json = """
                [
                    {
                        "idRegistroExtracto": 444,
                        "idExtracto": 72,
                        "fechaMovimiento": "2026-08-03",
                        "descripcionMovimiento": "COMPRA INTERNET",
                        "detalleMovimiento": null,
                        "debito": 25240200.0,
                        "credito": 0.0,
                        "nitTercero": "0",
                        "nombreTercero": null,
                        "tipoMovimiento": "N227",
                        "subTipoDocumento": null,
                        "cuentaContable": null
                    },
                    {
                        "idRegistroExtracto": 446,
                        "idExtracto": 72,
                        "fechaMovimiento": "2026-08-06",
                        "descripcionMovimiento": "TRANSFERENCIA OTRA ENTIDAD",
                        "detalleMovimiento": "000008903990342  TRANSFER  PAGO PV AGOS 06",
                        "debito": 0.0,
                        "credito": 1541788.0,
                        "nitTercero": "8903990342",
                        "nombreTercero": null,
                        "tipoMovimiento": "N109",
                        "subTipoDocumento": "040",
                        "cuentaContable": "130505"
                    }
                ]
                """;

            var result = ExtractoRepository.MapMovements(json).ToList();

            Assert.Equal(2, result.Count);

            Assert.Equal(444, result[0].IdRegistroExtracto);
            Assert.Equal(72, result[0].IdExtracto);
            Assert.Equal("2026-08-03", result[0].FechaMovimiento);
            Assert.Equal("COMPRA INTERNET", result[0].DescripcionMovimiento);
            Assert.Null(result[0].DetalleMovimiento);
            Assert.Equal(25240200.0m, result[0].Debito);
            Assert.Equal(0.0m, result[0].Credito);
            Assert.Equal("0", result[0].NitTercero);
            Assert.Null(result[0].NombreTercero);
            Assert.Equal("N227", result[0].TipoMovimiento);
            Assert.Null(result[0].SubTipoDocumento);
            Assert.Null(result[0].CuentaContable);

            Assert.Equal(446, result[1].IdRegistroExtracto);
            Assert.Equal("TRANSFERENCIA OTRA ENTIDAD", result[1].DescripcionMovimiento);
            Assert.Equal("000008903990342  TRANSFER  PAGO PV AGOS 06", result[1].DetalleMovimiento);
            Assert.Equal(1541788.0m, result[1].Credito);
            Assert.Equal("130505", result[1].CuentaContable);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapMovements_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            var result = ExtractoRepository.MapMovements(json);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetMovementsAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new ExtractoRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => repository.GetMovementsAsync(72));
        }
    }
}
