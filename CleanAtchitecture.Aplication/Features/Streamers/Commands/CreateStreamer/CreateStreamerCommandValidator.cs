using FluentValidation;


namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands
{
    public class CreateCompanyCommandValidator : AbstractValidator <CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caractreres");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("La {Url} no puede estar en balnco");
        }
    }
}
