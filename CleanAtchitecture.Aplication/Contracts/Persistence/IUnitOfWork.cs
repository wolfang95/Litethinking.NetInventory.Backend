using Litethinking.NetInventory.Backend.Domain.Common;

namespace Litethinking.NetInventory.Backend.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        ICompanyRepository CompanyRepository { get; }
        IInventoryRepository InventoryRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
