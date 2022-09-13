namespace BancoDigital.Models
{
    public class AddContaInputModel
    {
        public string NumeroConta { get; set; }
        public string NumeroAgencia { get; set; }
        public string TipoConta { get; set; }
        public decimal Saldo { get; set; }
    }
}
