using AutoFixture;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Litethinking.NetInventory.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mock
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(CompanyDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var streamers = fixture.CreateMany<Company>().ToList();

            streamers.Add(fixture.Build<Company>()
               .With(tr => tr.Id, 8001)
               .Without(tr => tr.CompanyName)
               .Create()
           );

            streamerDbContextFake.Companies!.AddRange(streamers);
            streamerDbContextFake.SaveChanges();

        }
    }
}
