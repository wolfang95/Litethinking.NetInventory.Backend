

using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList;
using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetByIdList
{
    public class GetInventoriesbyCompanyIdListQueryHandler : IRequestHandler<GetInventoriesbyCompanyIdListQuery, List<InventoriesVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoriesbyCompanyIdListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<InventoriesVm>> Handle(GetInventoriesbyCompanyIdListQuery request, CancellationToken cancellationToken)
        {
            var inventoryList = await _unitOfWork.InventoryRepository.GetInventoryByCompanyId(request._CompanyId);

            return _mapper.Map<List<InventoriesVm>>(inventoryList);
        }
    }
}
