using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Models;
using Litethinking.NetInventory.Backend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Litethinking.NetInventory.Backend.Application.Features.Companies.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        //private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly ILogger<CreateCompanyCommandHandler> _logger;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailservice, ILogger<CreateCompanyCommandHandler> logger)
        {
            //_companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailservice = emailservice;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = _mapper.Map<Company>(request);
            //var newCompany = await _companyRepository.AddAsync(companyEntity);

            _unitOfWork.CompanyRepository.AddEntity(companyEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de company");
            }

            _logger.LogInformation($"Company {companyEntity.Id} fue creado existosamente");

            await SendEmail(companyEntity);

            return companyEntity.Id;
        }

        private async Task SendEmail(Company company)
        {
            var email = new Email
            {
                To = "corredor.wolfang@gmail.com",
                Body = "La compania de company se creo correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailservice.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email de {company.Id}");
            }

        }

    }
}
