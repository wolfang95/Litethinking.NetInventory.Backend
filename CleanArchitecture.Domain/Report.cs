
using Litethinking.NetInventory.Backend.Domain.Common;

namespace Litethinking.NetInventory.Backend.Domain
{
    public class Report : BaseDomainModel
    {
        public Report()
        {
        }

        public string? Export { get; set; }

        public string? User { get; set; }

        public int InventoryId { get; set; }

        public virtual Inventory? Inventory { get; set; }

    }
}
