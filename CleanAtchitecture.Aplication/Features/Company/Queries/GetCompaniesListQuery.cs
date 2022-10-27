using MediatR;


namespace Litethinking.NetInventory.Backend.Application.Features.Company.Queries
{
    public class GetCompaniesListQuery : IRequest<List<CompaniesVm>>
    {
        public string _Username { get; set; } = String.Empty;
        public GetCompaniesListQuery(string username)
        {
            _Username = username ?? throw new ArgumentException(nameof(username));
        }
    }
}