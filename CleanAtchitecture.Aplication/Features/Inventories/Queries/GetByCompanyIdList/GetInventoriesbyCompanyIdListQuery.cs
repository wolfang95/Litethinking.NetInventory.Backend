using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList;
using MediatR;


namespace Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetByIdList
{
    public class GetInventoriesbyCompanyIdListQuery : IRequest<List<InventoriesVm>>
    {
        public int _CompanyId{ get; set; } = 0;
        public GetInventoriesbyCompanyIdListQuery(int companyId)
        {
            _CompanyId = companyId;
        }
    }
}
