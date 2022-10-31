using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Features.Inventories.Queries.GetInventoriesList;
using Litethinking.NetInventory.Backend.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using Litethinking.NetInventory.Backend.Infrastructure.Repositories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Video.Queries
{
    public class GetVideosListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetVideosListQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();


            MockVideoRepository.AddDataVideoRepository(_unitOfWork.Object.CompanyDbContext);

        }

        [Fact]
        public async Task GetVideoListTest()
        {
            var handler = new GetInventoriesListQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetInventoriesListQuery("wolf");

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<InventoriesVm>>();

            result.Count.ShouldBe(1);
        }
    }
}
