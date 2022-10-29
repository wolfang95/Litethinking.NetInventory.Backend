using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain.Common;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using System.Collections;

namespace Litethinking.NetInventory.Backend.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly CompanyDbContext _context;

        private IInventoryRepository _inventoryRepository;
        private ICompanyRepository _companyRepository;

        //public ICompanyRepository

        public IInventoryRepository InventoryRepository => _inventoryRepository ??= new InventoryRepository(_context);

        public ICompanyRepository CompanyRepository => _companyRepository ??= new CompanyRepository(_context);

        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
        }

        public CompanyDbContext CompanyDbContext => _context;

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Err");
            }

        }



        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }


    }
}
