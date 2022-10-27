
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

        public int VideoId { get; set; }

        public virtual Video? Video { get; set; }

    }
}
