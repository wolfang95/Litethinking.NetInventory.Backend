using FluentValidation;
namespace Litethinking.NetInventory.Backend.Application.Features.Reports.Commands.CreateReport
{
    public class CreateCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Export)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(p => p.User)
                .NotNull().WithMessage("{Apellido} no puede ser nulo");
        }
    }
}
