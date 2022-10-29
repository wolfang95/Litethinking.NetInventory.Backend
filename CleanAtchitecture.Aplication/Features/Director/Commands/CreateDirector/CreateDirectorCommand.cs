using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommand : IRequest<int>
    {

        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int InventoryId { get; set; }
    }
}
