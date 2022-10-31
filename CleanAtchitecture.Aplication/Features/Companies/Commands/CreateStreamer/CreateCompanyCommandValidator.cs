using FluentValidation;


namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands
{
    public class CreateCompanyCommandValidator : AbstractValidator <CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(p => p.NIT)
                .NotEmpty().WithMessage("{NIT} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caractreres");

            RuleFor(p => p.CompanyName)
                .NotEmpty().WithMessage("La {Compnay Name} no puede estar en balnco");
        }
    }
}
