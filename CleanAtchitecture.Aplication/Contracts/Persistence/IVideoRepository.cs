using Litethinking.NetInventory.Backend.Domain;


namespace Litethinking.NetInventory.Backend.Application.Contracts.Persistence
{
    public interface IInventoryRepository : IAsyncRepository<Inventory>
    {

        Task<IEnumerable<Inventory>> GetInventoryByUsername(string username);

        Task<Inventory> GetInventoryByName(string nombreInventory);
        Task<IEnumerable<Inventory>> GetInventoryByCompanyId(int companyId);

    }
}
