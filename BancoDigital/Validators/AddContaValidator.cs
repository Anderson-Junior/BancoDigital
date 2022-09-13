using BancoDigital.Models;
using FluentValidation;

namespace BancoDigital.Validators
{
    public class AddContaValidator : AbstractValidator<AddContaInputModel>
    {
        public AddContaValidator()
        {
            RuleFor(x => x.NumeroConta)
                .NotEmpty()
                    .WithMessage("O número da conta não pode ser nulo ou vazio.")
                .MaximumLength(5)
                    .WithMessage("O número da conta não pode ter mais que 5 caracteres.")
                .MinimumLength(5)
                    .WithMessage("O número da conta não ter menos que 5 caracteres.");

            RuleFor(x => x.NumeroAgencia)
                .NotEmpty()
                    .WithMessage("A agencia não pode ser nula ou vazia.")
                .MaximumLength(4)
                    .WithMessage("A agencia não pode ter mais que 4 caracteres.")
                .MinimumLength(4)
                    .WithMessage("A agencia não pode ter menos que 4 caracteres.");

            RuleFor(x => x.TipoConta)
                .NotEmpty()
                    .WithMessage("O tipo da conta não pode ser nulo ou vazio.")
                .MaximumLength(10)
                    .WithMessage("O tipo da conta não pode ter mais que 10 caracteres")
                .MinimumLength(8)
                    .WithMessage("O tipo da conta não pode ter menos que 8 caracteres");

            RuleFor(x => x.Saldo)
                .NotEmpty()
                    .WithMessage("O saldo da conta não ser nulo ou vazio");
        }
    }
}
