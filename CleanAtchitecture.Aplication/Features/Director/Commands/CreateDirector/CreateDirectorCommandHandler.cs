using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Infrastructure;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Models;
using Litethinking.NetInventory.Backend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Litethinking.NetInventory.Backend.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, int>
    {
        private readonly ILogger<CreateDirectorCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailservice;
        private readonly IAzureBlobStorageService _azureBlobStorageService;

        public CreateDirectorCommandHandler(ILogger<CreateDirectorCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork, IEmailService emailservice, IAzureBlobStorageService azureBlobStorageService)
        {
            _logger = logger;
            _mapper = mapper;
            _emailservice = emailservice;
            _unitOfWork = unitOfWork;
            _azureBlobStorageService = azureBlobStorageService;
        }

        public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var directorEntity = _mapper.Map<Director>(request);

            _unitOfWork.Repository<Director>().AddEntity(directorEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("No se inserto el record del director");
                throw new Exception("No se pudo insertar el record del director");
            }

            await SendEmail();
            await UploadInventory();

            return directorEntity.Id;
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
