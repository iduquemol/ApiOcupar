using Microsoft.AspNetCore.Mvc;
using Moq;
using OcuparApi.Controllers;
using OcuparApi.Models;
using OcuparApi.Services;

namespace OcuparApi.Tests.Controllers
{
    public class CarteraControllerTests
    {
        [Fact]
        public async Task GetCartera_ReturnsOkWithRepositoryResult()
        {
            var items = new List<CarteraDocumento>
            {
                new() { CodigoCliente = "79217534", NitCliente = "79217534", NumeroDocumento = "FES12870" }
            };
            var repositoryMock = new Mock<ICarteraRepository>();
            repositoryMock.Setup(r => r.GetCarteraAsync("79217534")).ReturnsAsync(items);

            var controller = new CarteraController(repositoryMock.Object);

            var result = await controller.GetCartera("79217534");

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(items, okResult.Value);
        }
    }
}
