using Moq;
using OcuparApi.Services;

namespace OcuparApi.Tests.Services
{
    public class BankRepositoryTests
    {
        [Fact]
        public void MapBanks_WithMultipleEntries_MapsCodBanAndNomBanToIdAndName()
        {
            const string json = """
                [
                    { "cod_ban": "01", "nom_ban": "BANCO DE BOGOTÁ" },
                    { "cod_ban": "07", "nom_ban": "BANCOLOMBIA S.A." }
                ]
                """;

            var result = BankRepository.MapBanks(json).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("01", result[0].Id);
            Assert.Equal("BANCO DE BOGOTÁ", result[0].Name);
            Assert.Equal("07", result[1].Id);
            Assert.Equal("BANCOLOMBIA S.A.", result[1].Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void MapBanks_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            var result = BankRepository.MapBanks(json);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetBanksAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new BankRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetBanksAsync());
        }
    }
}
