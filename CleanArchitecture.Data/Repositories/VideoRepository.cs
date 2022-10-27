using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Litethinking.NetInventory.Backend.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {
        }
        public async Task<Video> GetVideoByName(string nombreVideo)
        {
            return await _context.Videos!.Where(o => o.Name == nombreVideo).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _context.Videos!.Where(v => v.CreatedBy == username).ToListAsync();
        }


    }
}