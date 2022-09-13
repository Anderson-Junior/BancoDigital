using BancoDigital.Data;
using BancoDigital.Entities;
using BancoDigital.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoDigital.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly ApplicationDbContext _context;

        public ContaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Conta>> GetAll()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<Conta> GetByConta(string numeroConta)
        {
            return await _context.Contas.FirstOrDefaultAsync(x => x.NumeroConta == numeroConta);
        }

        public async Task<Conta> AddConta(Conta conta)
        {
            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();

            return conta;
        }
    }
}
