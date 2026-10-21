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
    }
}
