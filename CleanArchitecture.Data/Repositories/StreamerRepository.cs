using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;

namespace Litethinking.NetInventory.Backend.Infrastructure.Repositories
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        public StreamerRepository(StreamerDbContext context) : base(context)
        { }
    }
}