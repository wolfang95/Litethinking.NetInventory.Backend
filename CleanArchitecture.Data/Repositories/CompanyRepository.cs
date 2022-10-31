using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Litethinking.NetInventory.Backend.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(CompanyDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companies!.Where(v => v.CreatedBy != "").ToListAsync();
        }



        public async Task<Company> GetInventoryByName(string nitSerial)
        {
            return await _context.Companies!.Where(o => o.NIT.ToString() == nitSerial).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetCompanyByUsername(string username)
        {
            return await _context.Companies!.Where(v => v.CreatedBy == username).ToListAsync();
        }
    }
}