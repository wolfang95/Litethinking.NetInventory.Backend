using AutoMapper;
using Litethinking.NetInventory.Backend.Application.Contracts.Persistence;
using Litethinking.NetInventory.Backend.Application.Features.Videos.Queries.GetVideosList;
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

namespace Litethinking.NetInventory.Backend.Application.UnitTests.Features.Video.Queries
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


            MockVideoRepository.AddDataVideoRepository(_unitOfWork.Object.StreamerDbContext);

        }

        [Fact]
        public async Task GetVideoListTest()
        {
            var handler = new GetVideosListQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetVideosListQuery("vaxidrez");

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<VideosVm>>();

            result.Count.ShouldBe(1);
        }
    }
}
