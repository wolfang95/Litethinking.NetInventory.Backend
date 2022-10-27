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
            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{dbContextId}")
                .Options;

            var streamerDbContextFake = new StreamerDbContext(options);
            streamerDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);


            return mockUnitOfWork;
        }

    }
}