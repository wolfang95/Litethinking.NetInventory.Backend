

using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Domain;

namespace Litethinking.NetInventory.Backend.Application.Contracts.Persistence
{
    public interface ICompanyRepository : IAsyncRepository<Company>
    {
        Task<Company> GetVideoByName(string nombreVideo);
        Task<IEnumerable<Company>> GetVideoByUsername(string username);

    }
}