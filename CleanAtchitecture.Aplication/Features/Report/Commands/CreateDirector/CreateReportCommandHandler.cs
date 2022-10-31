using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Models;
using Litethinking.NetInventory.Backend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Litethinking.NetInventory.Backend.Application.Features.Reports.Commands.CreateReport
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, int>
    {
        private readonly ILogger<CreateReportCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailservice;
        private readonly IAzureBlobStorageService _azureBlobStorageService;

        public CreateReportCommandHandler(ILogger<CreateReportCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork, IEmailService emailservice, IAzureBlobStorageService azureBlobStorageService)
        {
            _logger = logger;
            _mapper = mapper;
            _emailservice = emailservice;
            _unitOfWork = unitOfWork;
            _azureBlobStorageService = azureBlobStorageService;
        }

        public async Task<int> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var reportEntity = _mapper.Map<Report>(request);

            _unitOfWork.Repository<Report>().AddEntity(reportEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("No se inserto el record del report");
                throw new Exception("No se pudo insertar el record del report");
            }

            await SendEmail();
            await UploadInventory();

            return reportEntity.Id;
        }

        private async Task SendEmail()
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
                _logger.LogError($"Errores enviando el email de test azure");
            }

        }

        private async Task UploadInventory()
        {
            var email = new AzureBlobStorage
            {
                Conectionstring = "corredor.wolfang@gmail.com",
                Container = "La compania de company se creo correctamente",
            };

            try
            {
                await _azureBlobStorageService.AzureBlobStorageUpload(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email de test azure");
            }

        }


    }
}
