using Litethinking.NetInventory.Backend.Domain;


namespace Litethinking.NetInventory.Backend.Application.Contracts.Persistence
{
    public interface IInventoryRepository : IAsyncRepository<Inventory>
    {
        Task<Inventory> GetInventoryByName(string nombreInventory);
        Task<IEnumerable<Inventory>> GetInventoryByUsername(string username);

    }
}
