using AutoFixture;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;

namespace Litethinking.NetInventory.Backend.Application.UnitTests.Mocks
{
    public static class MockInventoryRepository
    {
        public static void AddDataInventoryRepository(CompanyDbContext companyDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var inventories = fixture.CreateMany<Inventory>().ToList();

            inventories.Add(fixture.Build<Inventory>()
                .With(tr => tr.CreatedBy, "vaxidrez")
                .Create()
            );

            companyDbContextFake.Inventories!.AddRange(inventories);
            companyDbContextFake.SaveChanges();
        }
    }
}
