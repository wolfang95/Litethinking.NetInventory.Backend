using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Litethinking.NetInventory.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Litethinking.NetInventory.Backend.Infraestructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(StreamerDbContext context) : base(context)
        {
        }
        public async Task<Company> GetVideoByName(string nombreVideo)
        {
            return await _context.Companies!.Where(o => o.CompanyName == nombreVideo).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetVideoByUsername(string username)
        {
            return await _context.Companies!.Where(v => v.CompanyName == username).ToListAsync();
        }


    }
}