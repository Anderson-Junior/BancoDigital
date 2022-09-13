using BancoDigital.Entities;
using BancoDigital.Models;
using BancoDigital.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BancoDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _service;

        public ContaController(IContaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContas()
        {
            var contas = await _service.GetAll();

            if (contas == null)
                return NoContent();

            return Ok(contas);
        }

        [HttpGet("/Conta/{numeroConta}")]
        public async Task<IActionResult> GetByConta(string numeroConta)
        {
            var conta = await _service.GetByConta(numeroConta);

            if (conta == null)
                return NoContent();

            return Ok(conta);
        }

        [HttpPost]
        public async Task<IActionResult> AddConta(AddContaInputModel contaInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                Conta conta = new Conta
                {
                    NumeroConta = contaInputModel.NumeroConta,
                    NumeroAgencia = contaInputModel.NumeroAgencia,
                    Saldo = contaInputModel.Saldo,
                    TipoConta = contaInputModel.TipoConta,
                    CriadaEm = DateTime.Now
                };
                await _service.AddConta(conta);
                return CreatedAtAction(nameof(GetByConta), new { numeroConta = conta.NumeroConta }, conta);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao adicionar uma nova conta. ", ex);
            }  
        }
    }
}
