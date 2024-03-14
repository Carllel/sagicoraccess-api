using AutoMapper;
using Moq;
using Sagicor.Access.Application.Contracts.Logging;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Application.Exceptions;
using Sagicor.Access.Application.Features.PLCategory.Commands.CreatePLCategory;
using Sagicor.Access.Application.MappingProfiles;
using Sagicor.Access.Application.UnitTests.Mocks;
using Sagicor.Access.Domain.Entities;
using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.UnitTests.Features.PLCategories.Commands
{
    public class CreatePLCategoryCommandHandlerTests
    {
        private readonly Mock<IPLCategoryRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<CreatePLCategoryCommandHandler>> _mockAppLogger;

        public CreatePLCategoryCommandHandlerTests()
        {
            _mockRepo = MockPLCategoryRepository.GetMockPLCategoryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<PLCategoryProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<CreatePLCategoryCommandHandler>>();
        }

        [Fact]
        public async Task HandleValidPLCategoryTest()
        {
            var handler = new CreatePLCategoryCommandHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            await handler.Handle(new CreatePLCategoryCommand()
            {
                Code = "52903",
                Description = "Test PL Category 4"
            }, CancellationToken.None);

            var pLCategories = await _mockRepo.Object.GetAsync();
            pLCategories.Count.ShouldBe(4);
        }

        //BadRequestException Test
        [Fact]
        public async Task HandleValidPLCategoryBadRequestExceptionTest()
        {
            var handler = new CreatePLCategoryCommandHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var newPlCategory = new CreatePLCategoryCommand
            {
                //Id = Guid.NewGuid(),
                Code = "52902",
                Description = "Test PL Category 3"
            };

            await Should.ThrowAsync<BadRequestException>(handler.Handle(newPlCategory, CancellationToken.None));
        }
    }
}
