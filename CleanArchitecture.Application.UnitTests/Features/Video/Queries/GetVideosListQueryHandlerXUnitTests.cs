using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList;
using Litethinking.NetInventory.Backend.Application.Mappings;
using Litethinking.NetInventory.Backend.Application.UnitTests.Mocks;
using Litethinking.NetInventory.Backend.Infrastructure.Repositories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Litethinking.NetInventory.Backend.Application.UnitTests.Features.Inventory.Queries
{
    public class GetInventoriesListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetInventoriesListQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            MockInventoryRepository.AddDataInventoryRepository(_unitOfWork.Object.CompanyDbContext);

        }

        [Fact]
        public async Task GetInventoryListTest()
        {
            var handler = new GetInventoriesListQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetInventoriesListQuery("vaxidrez");

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<InventoriesVm>>();

            result.Count.ShouldBe(1);
        }
    }
}
