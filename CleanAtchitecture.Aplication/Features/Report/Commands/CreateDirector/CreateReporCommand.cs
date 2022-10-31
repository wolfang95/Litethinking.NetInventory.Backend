using MediatR;

namespace Litethinking.NetInventory.Backend.Application.Features.Reports.Commands.CreateReport
{
    public class CreateReportCommand : IRequest<int>
    {

        public string Export { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public int InventoryId { get; set; }
    }
}
