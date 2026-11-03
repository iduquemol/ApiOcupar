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
        public void MapSucursales_WithMultipleEntries_MapsToCodigoAndNombre()
        {
            const string json = """
                [
                    { "cod_suc": "01", "nom_suc": "CALI" },
                    { "cod_suc": "04", "nom_suc": "BOGOTA" }
                ]
                """;

            var result = CatalogosRepository.MapSucursales(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("01", result[0].Codigo);
            Assert.Equal("CALI", result[0].Nombre);
            Assert.Equal("04", result[1].Codigo);
            Assert.Equal("BOGOTA", result[1].Nombre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapSucursales_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapSucursales(json));
        }

        [Fact]
        public void MapCentrosCosto_WithMultipleEntries_MapsToCodigoAndNombre()
        {
            const string json = """
                [
                    { "cod_cco": "0", "nom_cco": "NO APLICA" },
                    { "cod_cco": "010130", "nom_cco": "OCUPAR ADMINISTRACION" }
                ]
                """;

            var result = CatalogosRepository.MapCentrosCosto(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("0", result[0].Codigo);
            Assert.Equal("NO APLICA", result[0].Nombre);
            Assert.Equal("010130", result[1].Codigo);
            Assert.Equal("OCUPAR ADMINISTRACION", result[1].Nombre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapCentrosCosto_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapCentrosCosto(json));
        }

        [Fact]
        public void MapCiudades_WithMultipleEntries_MapsAllFields()
        {
            const string json = """
                [
                    { "cod_ciu": "05001", "cod_dep": "05", "cod_pai": "057", "nom_ciu": "MEDELLIN - ANTIOQUIA - COLOMBIA" },
                    { "cod_ciu": "76001", "cod_dep": "76", "cod_pai": "057", "nom_ciu": "CALI - VALLE - COLOMBIA" }
                ]
                """;

            var result = CatalogosRepository.MapCiudades(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("05001", result[0].Codigo);
            Assert.Equal("MEDELLIN - ANTIOQUIA - COLOMBIA", result[0].Nombre);
            Assert.Equal("05", result[0].CodigoDepartamento);
            Assert.Equal("057", result[0].CodigoPais);
            Assert.Equal("76001", result[1].Codigo);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapCiudades_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapCiudades(json));
        }

        [Fact]
        public void MapClasificador1_WithMultipleEntries_MapsToCodigoAndNombre()
        {
            const string json = """
                [
                    { "cod_cl1": "0", "nom_cl1": "NO APLICA" },
                    { "cod_cl1": "1", "nom_cl1": "ADMINISTRATIVO" }
                ]
                """;

            var result = CatalogosRepository.MapClasificador1(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("0", result[0].Codigo);
            Assert.Equal("NO APLICA", result[0].Nombre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapClasificador1_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapClasificador1(json));
        }

        [Fact]
        public void MapClasificador2_WithMultipleEntries_MapsToCodigoAndNombre()
        {
            const string json = """
                [
                    { "cod_cl2": "0", "nom_cl2": "NO APLICA" },
                    { "cod_cl2": "1", "nom_cl2": "OPERATIVO" }
                ]
                """;

            var result = CatalogosRepository.MapClasificador2(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("0", result[0].Codigo);
            Assert.Equal("NO APLICA", result[0].Nombre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapClasificador2_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapClasificador2(json));
        }

        [Fact]
        public void MapClasificador3_WithMultipleEntries_MapsToCodigoAndNombre()
        {
            const string json = """
                [
                    { "cod_cl3": "0", "nom_cl3": "NO APLICA" },
                    { "cod_cl3": "1", "nom_cl3": "COMERCIAL" }
                ]
                """;

            var result = CatalogosRepository.MapClasificador3(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("0", result[0].Codigo);
            Assert.Equal("NO APLICA", result[0].Nombre);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapClasificador3_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapClasificador3(json));
        }

        [Fact]
        public void MapRetenciones_WithMultipleEntries_MapsAllFields()
        {
            const string json = """
                [
                    { "cod_ret": "009", "nombre": "10.00% HONORARIOS( NO DECLARANTES DE RENTA)", "por_ret": 10.0, "cta_ret": "23651501", "nom_cta": "HONORARIOS 10%" },
                    { "cod_ret": "010", "nombre": "4% COMPRAS", "por_ret": 4.0, "cta_ret": "23652502", "nom_cta": "COMPRAS 4%" }
                ]
                """;

            var result = CatalogosRepository.MapRetenciones(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("009", result[0].Codigo);
            Assert.Equal("10.00% HONORARIOS( NO DECLARANTES DE RENTA)", result[0].Nombre);
            Assert.Equal(10.0m, result[0].Porcentaje);
            Assert.Equal("23651501", result[0].CuentaContable);
            Assert.Equal("HONORARIOS 10%", result[0].NombreCuenta);
            Assert.Equal("010", result[1].Codigo);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapRetenciones_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            Assert.Empty(CatalogosRepository.MapRetenciones(json));
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

        [Fact]
        public async Task GetSucursalesAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetSucursalesAsync());
        }

        [Fact]
        public async Task GetCentrosCostoAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetCentrosCostoAsync());
        }

        [Fact]
        public async Task GetCiudadesAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetCiudadesAsync());
        }

        [Fact]
        public async Task GetClasificador1Async_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetClasificador1Async());
        }

        [Fact]
        public async Task GetClasificador2Async_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetClasificador2Async());
        }

        [Fact]
        public async Task GetClasificador3Async_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetClasificador3Async());
        }

        [Fact]
        public async Task GetRetencionesAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new CatalogosRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetRetencionesAsync());
        }
    }
}
