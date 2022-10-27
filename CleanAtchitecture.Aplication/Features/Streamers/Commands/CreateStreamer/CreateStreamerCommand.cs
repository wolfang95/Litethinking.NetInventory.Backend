using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

    }
}
