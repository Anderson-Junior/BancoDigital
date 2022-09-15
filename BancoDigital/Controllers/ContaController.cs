using AutoMapper;
using BancoDigital.Entities;
using BancoDigital.Models;
using BancoDigital.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _service;
        private readonly IMapper _autoMapper;

        public ContaController(IContaService service, IMapper autoMapper)
        {
            _service = service;
            _autoMapper = autoMapper;
        }

        [HttpGet("/ListarContas")]
        public async Task<IActionResult> GetAllContas()
        {
            var contas = await _service.GetAll();
            if (contas == null)
                return NotFound("Nenhuma conta cadastrada.");

            return Ok(_autoMapper.Map<IEnumerable<ContaViewModel>>(contas));
        }

        [HttpGet("/PesquisarConta/{numeroConta}")]
        public async Task<IActionResult> GetByConta(string numeroConta)
        {
            var conta = await _service.GetByConta(numeroConta);

            if (conta == null)
                return NotFound("Conta não encontrada.");

            return Ok(_autoMapper.Map<ContaViewModel>(conta));
        }

        [HttpPost("/AdicionarNovaConta")]
        public async Task<IActionResult> AddConta(AddContaInputModel contaInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var novaConta = _autoMapper.Map<Conta>(contaInputModel);

                await _service.AddConta(novaConta);
                return CreatedAtAction(nameof(GetByConta), new { numeroConta = novaConta.NumeroConta }, _autoMapper.Map<ContaViewModel>(novaConta));
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao adicionar uma nova conta. ", ex);
            }  
        }

        [HttpGet("/Saldo/{numeroConta}")]
        public async Task<IActionResult> Saldo(string numeroConta)
        {
            var conta = await _service.GetByConta(numeroConta);

            if (conta == null)
                return NotFound("Conta não encontrada.");

            return Ok($"Saldo: R${ conta.Saldo }");
        }

        [HttpPut("{numeroConta}/Depositar")]
        public async Task<IActionResult> Depositar(string numeroConta, [FromBody] decimal valor)
        {
            var contaExiste = await _service.GetByConta(numeroConta);
            if (contaExiste == null)
                return NotFound("Conta não encontrada.");

            try
            {
                contaExiste.Saldo += valor;
                contaExiste.AtualizadaEm = DateTime.Now;

                await _service.Depositar(contaExiste);
                return Ok(_autoMapper.Map<ContaViewModel>(contaExiste));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao depositar valor. ", ex);
            }
        }

        [HttpPut("{numeroConta}/Sacar")]
        public async Task<IActionResult> Sacar(string numeroConta, [FromBody] decimal valor)
        {
            var contaExiste = await _service.GetByConta(numeroConta);
            if (contaExiste == null)
                return NotFound("Conta não encontrada.");

            try
            {
                if(contaExiste.Saldo < valor)
                {
                    return BadRequest("Saldo insulficiente");
                }

                contaExiste.Saldo -= valor;
                contaExiste.AtualizadaEm = DateTime.Now;

                await _service.Sacar(contaExiste);
                return Ok(_autoMapper.Map<ContaViewModel>(contaExiste));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao sacar valor. ", ex);
            }
        }
    }
}
