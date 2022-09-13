using BancoDigital.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoDigital.Services
{
    public interface IContaService
    {
        Task<List<Conta>> GetAll();
        Task<Conta> GetByConta(string numeroConta);
        Task<Conta> AddConta(Conta conta);
        Task<Conta> Depositar(Conta conta);
        Task<Conta> Sacar(Conta conta);
    }
}
