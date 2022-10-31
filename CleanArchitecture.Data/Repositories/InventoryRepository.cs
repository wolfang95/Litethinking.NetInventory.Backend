using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Litethinking.NetInventory.Backend.Infrastructure.Repositories
{
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(CompanyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Inventory>> GetInventoryByCompanyId(int CompanyId)
        {
            return await _context.Inventories!.Where(v => v.CompanyId == CompanyId).ToListAsync();
        }
        public async Task<Inventory> GetInventoryByName(string nombreInventory)
        {
            return await _context.Inventories!.Where(o => o.NameInventory == nombreInventory).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Inventory>> GetInventoryByUsername(string username)
        {
            return await _context.Inventories!.Where(v => v.CreatedBy == username).ToListAsync();
        }


    }
}