using MediatR;


namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
