using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Exceptions;
using Litethinking.NetInventory.Backend.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Litethinking.NetInventory.Backend.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, Contracts.Infrastructure.IEmailService @object, ILogger<DeleteStreamerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            //var streamerToUpdate =  await  _streamerRepository.GetByIdAsync(request.Id);
            var streamerToUpdate = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);

            if (streamerToUpdate == null)
            {
                _logger.LogError($"No se encontro el streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));



            //await _streamerRepository.UpdateAsync(streamerToUpdate);

            _unitOfWork.StreamerRepository.UpdateEntity(streamerToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el streamer {request.Id}");

            return Unit.Value;
        }
    }
}
