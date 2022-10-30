using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Queries.GetAllCompaniesListQuery
{
    public class GetAllCompaniesListQueryHandler : IRequestHandler<GetAllCompaniesListQuery, List<CompaniesVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCompaniesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CompaniesVm>> Handle(GetAllCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _unitOfWork.CompanyRepository.GetAllAsync();

            return _mapper.Map<List<CompaniesVm>>(videoList);
        }

    }
}