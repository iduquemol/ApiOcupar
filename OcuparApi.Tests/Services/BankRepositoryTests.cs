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

        [Fact]
        public void MapAccounts_WithMatchingBankAndAccounts_MapsToBankAccount()
        {
            const string json = """
                [
                    { "cod_ban": "01", "nom_ban": "BANCO DE BOGOTÁ", "cuentasBancos": null },
                    {
                        "cod_ban": "07",
                        "nom_ban": "BANCOLOMBIA S.A.",
                        "cuentasBancos": [
                            {
                                "bancos": "01",
                                "nombre": "BANCOLOMBIA   30657094276",
                                "ctabanco": "30657094276",
                                "tipoCuenta": "Cuenta Corriente"
                            }
                        ]
                    }
                ]
                """;

            var result = BankRepository.MapAccounts(json, "07").ToList();

            Assert.Single(result);
            Assert.Equal("30657094276", result[0].Id);
            Assert.Equal("07", result[0].BankId);
            Assert.Equal("BANCOLOMBIA   30657094276", result[0].Name);
            Assert.Equal("30657094276", result[0].AccountNumber);
            Assert.Equal("Cuenta Corriente", result[0].TipoCuenta);
        }

        [Fact]
        public void MapAccounts_WhenMatchedBankHasNullAccounts_ReturnsEmptyList()
        {
            const string json = """
                [
                    { "cod_ban": "01", "nom_ban": "BANCO DE BOGOTÁ", "cuentasBancos": null }
                ]
                """;

            var result = BankRepository.MapAccounts(json, "01");

            Assert.Empty(result);
        }

        [Fact]
        public void MapAccounts_WhenNoBankMatchesRequestedId_ReturnsEmptyList()
        {
            const string json = """
                [
                    { "cod_ban": "01", "nom_ban": "BANCO DE BOGOTÁ", "cuentasBancos": null }
                ]
                """;

            var result = BankRepository.MapAccounts(json, "99");

            Assert.Empty(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void MapAccounts_WithNullOrEmptyJson_ReturnsEmptyList(string? json)
        {
            var result = BankRepository.MapAccounts(json, "07");

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAccountsByBankAsync_WhenConnectionFactoryThrows_PropagatesException()
        {
            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CreateConnection())
                .Throws(new InvalidOperationException("connection failed"));

            var repository = new BankRepository(factoryMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => repository.GetAccountsByBankAsync("07"));
        }
    }
}
