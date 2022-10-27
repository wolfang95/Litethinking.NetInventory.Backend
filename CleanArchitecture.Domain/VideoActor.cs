

using Litethinking.NetInventory.Backend.Domain.Common;

namespace Litethinking.NetInventory.Backend.Domain
{
    public class VideoActor : BaseDomainModel
    {
        public int VideoId { get; set; }
        public int ActorId { get; set; }

    }
}
