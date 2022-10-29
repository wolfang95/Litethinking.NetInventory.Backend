using FluentValidation;


namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{Name} no permite valores nulos");

            RuleFor(x => x.Url)
                .NotNull().WithMessage("{Url} no permite valores nulos");


        }
    }
}
