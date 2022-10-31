using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string NIT { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

    }
}
