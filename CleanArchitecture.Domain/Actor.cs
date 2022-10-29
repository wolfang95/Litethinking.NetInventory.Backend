
namespace Litethinking.NetInventory.Backend.Domain
{
    public class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }

    }
}
