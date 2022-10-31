
namespace Litethinking.NetInventory.Backend.Domain
{
    public class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
        }
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }

    }
}
