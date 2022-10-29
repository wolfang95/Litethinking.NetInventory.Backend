using Litethinking.NetInventory.Backend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litethinking.NetInventory.Backend.Domain
{
    public class Inventory : BaseDomainModel
    {
        public Inventory()
        {
            Products = new HashSet<Product>();
        }
        public string? Name { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Director Director { get; set; }


    }
}
