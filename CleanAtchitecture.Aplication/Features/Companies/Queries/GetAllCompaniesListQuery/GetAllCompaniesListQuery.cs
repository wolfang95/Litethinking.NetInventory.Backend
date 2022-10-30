using MediatR;


namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Queries.GetAllCompaniesListQuery
{
    public class GetAllCompaniesListQuery : IRequest<List<CompaniesVm>>
    {
        public string _Username { get; set; } = String.Empty;

        public GetAllCompaniesListQuery()
        {
            //_Username = username ?? throw new ArgumentException(nameof(username));
        }
    }
}