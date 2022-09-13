using System;

namespace BancoDigital.Models
{
    public class ContaViewModel
    {
        public string NumeroConta { get; set; }
        public string NumeroAgencia { get; set; }
        public string TipoConta { get; set; }
        public decimal Saldo { get; set; }
        public DateTime CriadaEm { get; set; }
        public DateTime AtualizadaEm { get; set; }
    }
}
