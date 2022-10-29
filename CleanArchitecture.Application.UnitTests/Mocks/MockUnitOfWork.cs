using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Litethinking.NetInventory.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Litethinking.NetInventory.Backend.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {


        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<CompanyDbContext>()
                .UseInMemoryDatabase(databaseName: $"CompanyDbContext-{dbContextId}")
                .Options;

            var companyDbContextFake = new CompanyDbContext(options);
            companyDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(companyDbContextFake);


            return mockUnitOfWork;
        }

    }
}