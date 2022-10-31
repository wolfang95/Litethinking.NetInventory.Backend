using AutoFixture;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static void AddDataVideoRepository(CompanyDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var videos = fixture.CreateMany<Inventory>().ToList();

            videos.Add(fixture.Build<Inventory>()
                .With(tr => tr.CreatedBy, "wolf")
                .Create()
            );

            streamerDbContextFake.Inventories!.AddRange(videos);
            streamerDbContextFake.SaveChanges();
        }
    }
}
