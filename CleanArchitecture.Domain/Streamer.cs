using Litethinking.NetInventory.Backend.Domain.Common;
namespace Litethinking.NetInventory.Backend.Domain
{
    public class Streamer : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public ICollection<Video>? Videos { get; set; }

    }
}
