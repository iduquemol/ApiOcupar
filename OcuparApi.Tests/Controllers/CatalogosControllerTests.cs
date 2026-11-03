using Microsoft.AspNetCore.Mvc;
using Moq;
using OcuparApi.Controllers;
using OcuparApi.Models;
using OcuparApi.Services;

namespace OcuparApi.Tests.Controllers
{
    public class CatalogosControllerTests
    {
        [Fact]
        public async Task GetTerceros_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CatalogItem> { new() { Codigo = "1000570208", Nombre = "OCHOA TRUJILLO LUCAS" } };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetTercerosAsync()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetTerceros();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetCuentasContables_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CatalogItem> { new() { Codigo = "00", Nombre = "NO APLICA" } };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetCuentasContablesAsync()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetCuentasContables();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetSubTiposDocumento_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CatalogItem> { new() { Codigo = "040", Nombre = "COMPROBANTE DE INGRESO CxC" } };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetSubTiposDocumentoAsync()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetSubTiposDocumento();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetSucursales_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CatalogItem> { new() { Codigo = "01", Nombre = "CALI" } };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetSucursalesAsync()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetSucursales();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetCentrosCosto_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CatalogItem> { new() { Codigo = "0", Nombre = "NO APLICA" } };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetCentrosCostoAsync()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetCentrosCosto();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetCiudades_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CiudadItem>
            {
                new() { Codigo = "05001", Nombre = "MEDELLIN - ANTIOQUIA - COLOMBIA", CodigoDepartamento = "05", CodigoPais = "057" }
            };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetCiudadesAsync()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetCiudades();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetClasificador1_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CatalogItem> { new() { Codigo = "0", Nombre = "NO APLICA" } };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetClasificador1Async()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetClasificador1();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetClasificador2_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CatalogItem> { new() { Codigo = "0", Nombre = "NO APLICA" } };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetClasificador2Async()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetClasificador2();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetClasificador3_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CatalogItem> { new() { Codigo = "0", Nombre = "NO APLICA" } };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetClasificador3Async()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetClasificador3();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }

        [Fact]
        public async Task GetRetenciones_ReturnsOkWithRepositoryResult()
        {
            var items = new List<RetencionItem>
            {
                new() { Codigo = "009", Nombre = "10.00% HONORARIOS", Porcentaje = 10.0m, CuentaContable = "23651501", NombreCuenta = "HONORARIOS 10%" }
            };
            var repositoryMock = new Mock<ICatalogosRepository>();
            repositoryMock.Setup(r => r.GetRetencionesAsync()).ReturnsAsync(items);

            var controller = new CatalogosController(repositoryMock.Object);

            var result = await controller.GetRetenciones();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }
    }
}
