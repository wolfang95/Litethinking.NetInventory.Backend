using Litethinking.NetInventory.Backend.Domain;

namespace Litethinking.NetInventory.Backend.Application.Contracts.Persistence
{
    public interface ICompanyRepository : IAsyncRepository<Company>
    {
        Task<Company> GetInventoryByName(string nombreInventory);
        Task<IEnumerable<Company>> GetCompanyByUsername(string username);
    }
}
