using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Queries
{
    public class GetCompaniesListQueryHandler : IRequestHandler<GetCompaniesListQuery, List<CompaniesVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetCompaniesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CompaniesVm>> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _unitOfWork.CompanyRepository.GetCompanyByUsername(request._Username);

            return _mapper.Map<List<CompaniesVm>>(videoList);
        }
    
    }
}
