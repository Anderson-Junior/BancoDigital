using BancoDigital.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BancoDigital.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
