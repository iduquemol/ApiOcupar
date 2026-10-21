using Moq;
using OcuparApi.Services;

namespace OcuparApi.Tests.Services
{
    public class CatalogosRepositoryTests
    {
        [Fact]
        public void MapTerceros_WithMultipleEntries_MapsToCodigoAndNombre()
        {
            const string json = """
                [
                    { "ter_nit": "1000570208", "ter_nombre": "OCHOA TRUJILLO LUCAS" },
                    { "ter_nit": "800186061", "ter_nombre": "MOVISTAR" }
                ]
                """;

            var result = CatalogosRepository.MapTerceros(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("1000570208", result[0].Codigo);
            Assert.Equal("OCHOA TRUJILLO LUCAS", result[0].Nombre);
            Assert.Equal("800186061", result[1].Codigo);
            Assert.Equal("MOVISTAR", result[1].Nombre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapTerceros_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapTerceros(json));
        }

        [Fact]
        public void MapCuentasContables_WithMultipleEntries_MapsToCodigoAndNombre()
        {
            const string json = """
                [
                    { "cod_cta": "00", "nom_cta": "NO APLICA" },
                    { "cod_cta": "110502002", "nom_cta": "Cuenta corriente" }
                ]
                """;

            var result = CatalogosRepository.MapCuentasContables(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("00", result[0].Codigo);
            Assert.Equal("NO APLICA", result[0].Nombre);
            Assert.Equal("110502002", result[1].Codigo);
            Assert.Equal("Cuenta corriente", result[1].Nombre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapCuentasContables_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapCuentasContables(json));
        }

        [Fact]
        public void MapSubTiposDocumento_WithMultipleEntries_MapsToCodigoAndNombre()
        {
            const string json = """
                [
                    { "cod_sub": "040", "nom_sub": "COMPROBANTE DE INGRESO CxC" },
                    { "cod_sub": "230", "nom_sub": "NOTA CREDITO BANCARIA" }
                ]
                """;

            var result = CatalogosRepository.MapSubTiposDocumento(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("040", result[0].Codigo);
            Assert.Equal("COMPROBANTE DE INGRESO CxC", result[0].Nombre);
            Assert.Equal("230", result[1].Codigo);
            Assert.Equal("NOTA CREDITO BANCARIA", result[1].Nombre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapSubTiposDocumento_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapSubTiposDocumento(json));
        }

        [Fact]
        public async Task GetTercerosAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetTercerosAsync());
        }

        [Fact]
        public async Task GetCuentasContablesAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetCuentasContablesAsync());
        }

        [Fact]
        public async Task GetSubTiposDocumentoAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetSubTiposDocumentoAsync());
        }
    }
}
