

using Litethinking.NetInventory.Backend.Domain.Common;

namespace Litethinking.NetInventory.Backend.Domain
{
    public class InventoryProduct : BaseDomainModel
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }

    }
}
