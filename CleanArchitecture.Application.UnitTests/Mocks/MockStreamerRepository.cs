using AutoFixture;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Litethinking.NetInventory.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Litethinking.NetInventory.Backend.Application.UnitTests.Mock
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var streamers = fixture.CreateMany<Streamer>().ToList();

            streamers.Add(fixture.Build<Streamer>()
               .With(tr => tr.Id, 8001)
               .Without(tr => tr.Videos)
               .Create()
           );

            streamerDbContextFake.Streamers!.AddRange(streamers);
            streamerDbContextFake.SaveChanges();

        }
    }
}
