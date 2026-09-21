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
    }
}
