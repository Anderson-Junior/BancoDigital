using AutoMapper;
using BancoDigital.Controllers;
using BancoDigital.Models;
using BancoDigital.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BancoDigital.Testes.Controllers
{
    public class ContaControllerTest
    {
        [Fact]
        public async Task GetAllContas_OK()
        {
            var service = new Mock<IContaService>();
            var mapper = new Mock<IMapper>();

            var conta = new ContaController(service.Object, mapper.Object);

            var okResult = await conta.GetAllContas();

            Assert.NotNull(okResult);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async Task GetContasByNumeroConta_OK()
        {
            var service = new Mock<IContaService>();
            var mapper = new Mock<IMapper>();

            var conta = new ContaController(service.Object, mapper.Object);

            var okResult = await conta.GetByConta("25654");

            Assert.NotNull(okResult);
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public async Task ContaNaoEncontrada()
        {
            var service = new Mock<IContaService>();
            var mapper = new Mock<IMapper>();

            var conta = new ContaController(service.Object, mapper.Object);
            decimal valor = 10.000m;
            string numeroConta = "63254";
            var result = await conta.Sacar(numeroConta, valor);

            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task CadastrarNovaConta()
        {
            var service = new Mock<IContaService>();
            var mapper = new Mock<IMapper>();
            var inputModel = new AddContaInputModel();

            inputModel.NumeroConta = "12365";
            inputModel.NumeroAgencia = "0014";
            inputModel.TipoConta = "corrente";
            inputModel.Saldo = 400;

            var conta = new ContaController(service.Object, mapper.Object);
            var result = await conta.AddConta(inputModel);

            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}
