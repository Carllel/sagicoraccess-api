using AutoMapper;
using Moq;
using Sagicor.Access.Application.Contracts.Logging;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Application.Exceptions;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetails;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetailsByCode;
using Sagicor.Access.Application.MappingProfiles;
using Sagicor.Access.Application.UnitTests.Mocks;
using Sagicor.Access.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.UnitTests.Features.PLCategories.Queries
{
    public class GetPLCategoryDetailsByCodeQueryHandlerTests
    {
        private IMapper _mapper;
        private Mock<IPLCategoryRepository> _mockRepo;
        private Mock<IAppLogger<GetPLCategoryDetailsByCodeQueryHandler>> _mockAppLogger;

        public GetPLCategoryDetailsByCodeQueryHandlerTests()
        {
            _mockRepo = MockPLCategoryRepository.GetMockPLCategoryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PLCategoryProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetPLCategoryDetailsByCodeQueryHandler>>();
        }

        [Fact]
        public async Task GetPLCategoryDetailsByCodeTest()
        {
            var _handler = new GetPLCategoryDetailsByCodeQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);
            // Arrange
            var code = "52900";
            var query = new GetPLCategoryDetailsByCodeQuery (code);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<PLCategoryDetailsByCodeDto>();
            result.Code.ShouldBe(code);
        }

        [Fact]
        public async Task GetPLCategoryDetailsByCodeThrowsNotFoundExceptionTest()
        {
            var _handler = new GetPLCategoryDetailsByCodeQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);
            // Arrange
            var code = "9999999";
            var query = new GetPLCategoryDetailsByCodeQuery (code);

             // Act & Assert
            await Should.ThrowAsync<NotFoundException>( _handler.Handle(query, CancellationToken.None)); 
        }

    }
}
