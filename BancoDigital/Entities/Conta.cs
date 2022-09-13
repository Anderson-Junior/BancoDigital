using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDigital.Entities
{
    [Table("Conta")]
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ContaId { get; set; }
        public string NumeroConta { get; set; }
        public string NumeroAgencia { get; set; }
        public string TipoConta { get; set; }
        public decimal Saldo { get; set; }
        public DateTime CriadaEm { get; set; }
        public DateTime AtualizadaEm { get; set; }

        public Conta() {}

        public Conta(string numeroConta, string numeroAgencia, string tipoConta, decimal saldo, DateTime criadaEm, DateTime atualizadaEm)
        {
            NumeroConta = numeroConta;
            NumeroAgencia = numeroAgencia;
            TipoConta = tipoConta;
            Saldo = saldo;
            CriadaEm = criadaEm;
            AtualizadaEm = atualizadaEm;
        }
    }
}
