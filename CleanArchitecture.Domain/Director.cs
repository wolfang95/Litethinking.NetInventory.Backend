
using Litethinking.NetInventory.Backend.Domain.Common;

namespace Litethinking.NetInventory.Backend.Domain
{
    public class Director : BaseDomainModel
    {
        public Director()
        {
        }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public int InventoryId { get; set; }

        public virtual Inventory? Inventory { get; set; }

    }
}
