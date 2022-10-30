using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList
{
    public class GetInventoriesListQueryHandler : IRequestHandler<GetInventoriesListQuery, List<InventoriesVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public GetInventoriesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<InventoriesVm>> Handle(GetInventoriesListQuery request, CancellationToken cancellationToken)
        {
            var inventoryList = await _unitOfWork.InventoryRepository.GetInventoryByUsername(request._Username);

            return _mapper.Map<List<InventoriesVm>>(inventoryList);
        }
    }
}
