using Litethinking.NetInventory.Backend.Domain.Common;
namespace Litethinking.NetInventory.Backend.Domain
{
    public class Company : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }

    }
}
