using AutoMapper;
using Moq;
using Sagicor.Access.Application.Contracts.Logging;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetAllPLCategories;
using Sagicor.Access.Application.MappingProfiles;
using Sagicor.Access.Application.UnitTests.Mocks;
using Shouldly;

namespace Sagicor.Access.Application.UnitTests.Features.PLCategories.Queries
{
    public class GetPLCategoryListQueryHandlerTests
    {
        private readonly Mock<IPLCategoryRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetPLCategoriesQueryHandler>> _mockAppLogger;

        public GetPLCategoryListQueryHandlerTests()
        {
            _mockRepo = MockPLCategoryRepository.GetMockPLCategoryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PLCategoryProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetPLCategoriesQueryHandler>>();
        }

        [Fact]
        public async Task GetPLCategoryListTest()
        {
            var handler = new GetPLCategoriesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetPLCategoriesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<PLCategoryDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
