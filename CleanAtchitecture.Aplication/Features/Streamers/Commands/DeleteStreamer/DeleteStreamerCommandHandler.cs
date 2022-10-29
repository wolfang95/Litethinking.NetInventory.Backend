using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Exceptions;
using Litethinking.NetInventory.Backend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCompanyCommandHandler> _logger;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCompanyCommandHandler> logger)
        {
            //_companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToDelete = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id);
            if (companyToDelete == null)
            {
                _logger.LogError($"{request.Id} company no existe en el sistema");
                throw new NotFoundException(nameof(Company), request.Id);
            }

            //await _companyRepository.DeleteAsync(companyToDelete);
            _unitOfWork.CompanyRepository.DeleteEntity(companyToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.Id} company fue eliminado con exito");

            return Unit.Value;
        }
    }
}
