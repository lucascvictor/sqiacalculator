using FluentValidation;
using SQIACalculator.Domain.DTOs;

namespace SQIACalculator.API.Validators
{
    public class PosFixadoValidator : AbstractValidator<ConsultaPosFixadoDTO>
    {
        public PosFixadoValidator()
        {
            RuleFor(x => x.ValorInicial)
                .GreaterThan(0).WithMessage("O valor investido deve ser maior que zero.")
                .NotEmpty().WithMessage("O valor inicial deve ser informado.");

            RuleFor(x => x.DataInicial)
                .LessThanOrEqualTo(x => x.DataFinal)
                .WithMessage("A data de início deve ser menor ou igual à data final.")
                .NotEmpty().WithMessage("A data inicial deve ser informada.");

            RuleFor(x => x.DataFinal)
                .GreaterThanOrEqualTo(x => x.DataInicial)
                .WithMessage("A data final deve ser maior ou igual à data de início.")
                .NotEmpty().WithMessage("A data final deve ser informada.");
        }
    }
}
