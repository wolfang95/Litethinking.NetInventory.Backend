using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

    }
}
