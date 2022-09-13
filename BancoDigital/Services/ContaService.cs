using BancoDigital.Entities;
using BancoDigital.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoDigital.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<Conta> AddConta(Conta conta)
        {
            return await _contaRepository.AddConta(conta);
        }

        public async Task<List<Conta>> GetAll()
        {
            return await _contaRepository.GetAll();
        }

        public async Task<Conta> GetByConta(string conta)
        {
            return await _contaRepository.GetByConta(conta);
        }
    }
}
