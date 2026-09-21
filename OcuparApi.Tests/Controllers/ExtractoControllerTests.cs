using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OcuparApi.Controllers;
using OcuparApi.Models;
using OcuparApi.Services;

namespace OcuparApi.Tests.Controllers
{
    public class ExtractoControllerTests
    {
        [Fact]
        public async Task PostCajaSocial_ForwardsRawBodyAndReturnsOkWithIdExtracto()
        {
            const string json = "{\"codigoBanco\":\"32\",\"cajaSocial\":[]}";
            var body = JsonDocument.Parse(json).RootElement;

            var repositoryMock = new Mock<IExtractoRepository>();
            repositoryMock.Setup(r => r.LoadCajaSocialExtractoAsync(json)).ReturnsAsync(42);

            var controller = new ExtractoController(repositoryMock.Object);

            var result = await controller.PostCajaSocial(body);

            repositoryMock.Verify(r => r.LoadCajaSocialExtractoAsync(json), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<LoadExtractoResult>(okResult.Value);
            Assert.Equal(42, value.IdExtracto);
        }
    }
}
