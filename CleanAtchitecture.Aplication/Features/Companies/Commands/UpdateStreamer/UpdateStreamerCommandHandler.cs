using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Exceptions;
using Litethinking.NetInventory.Backend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands.UpdateCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCompanyCommandHandler> _logger;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, Contracts.Infrastructure.IEmailService @object, ILogger<DeleteCompanyCommandHandler> logger)
        {
            //_companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            //var companyToUpdate =  await  _companyRepository.GetByIdAsync(request.Id);
            var companyToUpdate = await _unitOfWork.CompanyRepository.GetByIdAsync(request.Id);

            if (companyToUpdate == null)
            {
                _logger.LogError($"No se encontro el company id {request.Id}");
                throw new NotFoundException(nameof(Company), request.Id);
            }

            _mapper.Map(request, companyToUpdate, typeof(UpdateCompanyCommand), typeof(Company));



            //await _companyRepository.UpdateAsync(companyToUpdate);

            _unitOfWork.CompanyRepository.UpdateEntity(companyToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el company {request.Id}");

            return Unit.Value;
        }
    }
}
