using Microsoft.AspNetCore.Mvc;
using Moq;
using OcuparApi.Controllers;
using OcuparApi.Models;
using OcuparApi.Services;

namespace OcuparApi.Tests.Controllers
{
    public class BankControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkWithBanksFromRepository()
        {
            var banks = new List<Bank>
            {
                new() { Id = "01", Name = "BANCO DE BOGOTÁ" },
                new() { Id = "07", Name = "BANCOLOMBIA S.A." }
            };

            var repositoryMock = new Mock<IBankRepository>();
            repositoryMock.Setup(r => r.GetBanksAsync()).ReturnsAsync(banks);

            var controller = new BankController(repositoryMock.Object);

            var result = await controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(banks, okResult.Value);
        }

        [Fact]
        public async Task GetAccounts_ReturnsOkWithAccountsFromRepository()
        {
            var accounts = new List<BankAccount>
            {
                new() { Id = "30657094276", BankId = "07", Name = "BANCOLOMBIA   30657094276", AccountNumber = "30657094276", TipoCuenta = "Cuenta Corriente" }
            };

            var repositoryMock = new Mock<IBankRepository>();
            repositoryMock.Setup(r => r.GetAccountsByBankAsync("07")).ReturnsAsync(accounts);

            var controller = new BankController(repositoryMock.Object);

            var result = await controller.GetAccounts("07");

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(accounts, okResult.Value);
        }
    }
}
