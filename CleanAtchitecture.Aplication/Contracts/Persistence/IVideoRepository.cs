using Litethinking.NetInventory.Backend.Domain;


namespace Litethinking.NetInventory.Backend.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideoByName(string nombreVideo);
        Task<IEnumerable<Video>> GetVideoByUsername(string username);

    }
}
