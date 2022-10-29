using AutoFixture;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Domain;
using Litethinking.NetInventory.Backend.Infrastructure.Persistence;
using Litethinking.NetInventory.Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Litethinking.NetInventory.Backend.Application.UnitTests.Mock
{
    public static class MockCompanyRepository
    {
        public static void AddDataCompanyRepository(CompanyDbContext companyDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var companys = fixture.CreateMany<Company>().ToList();

            companys.Add(fixture.Build<Company>()
               .With(tr => tr.Id, 8001)
               .Without(tr => tr.Inventories)
               .Create()
           );

            companyDbContextFake.Companies!.AddRange(companys);
            companyDbContextFake.SaveChanges();

        }
    }
}
