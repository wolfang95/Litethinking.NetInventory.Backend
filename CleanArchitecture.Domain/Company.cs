using Litethinking.NetInventory.Backend.Domain.Common;
namespace Litethinking.NetInventory.Backend.Domain
{
    public class Company : BaseDomainModel
    {
        public string? NIT { get; set; }
        public string? CompanyName { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }

    }
}
