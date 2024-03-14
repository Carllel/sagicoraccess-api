using Moq;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.UnitTests.Mocks
{
    public class MockPLCategoryRepository
    {
        public static Mock<IPLCategoryRepository> GetMockPLCategoryRepository()
        {
            var plCategories = new List<PLCategory>
            {
                new PLCategory
                {
                    Id = Guid.NewGuid(),
                    Code = "52900",
                    Description = $"Test PL Category 1"
                },
                new PLCategory
                {
                    Id = Guid.NewGuid(),
                    Code = "52901",
                    Description = $"Test PL Category 2"
                },
                new PLCategory
                {
                    Id = Guid.NewGuid(),
                    Code = "52902",
                    Description = $"Test PL Category 3"
                }
            };

            var newId = Guid.NewGuid();

            var mockRepo = new Mock<IPLCategoryRepository>();

            // Mock GetAll method
            mockRepo.Setup(repo => repo.GetAsync())
                .ReturnsAsync(plCategories); // Return true to indicate successful update

            // Mock GetByIdAsync method
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => new PLCategory { Id = id, Code = "MockCode", Description = "MockDescription" });

            //// Mock GetPLCategoryByCodeAsync method
            mockRepo.Setup(repo => repo.GetPLCategoryByCodeAsync(It.IsAny<string>()))
                .ReturnsAsync((string code) => plCategories.FirstOrDefault(category => category.Code == code));

            // Mock CreateAsync method
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<PLCategory>()))
                .Returns((PLCategory pLCategory) =>
                {
                    plCategories.Add(pLCategory);
                    return Task.CompletedTask;
                });
            //mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<PLCategory>()))
            //    .Returns((PLCategory category) =>
            //    {
            //        category.Id = newId; // Generate a new GUID for the category
            //        plCategories.Add(category);
            //        return category.Id;
            //    });

            // Mock UpdateAsync method
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<PLCategory>()))
                .Returns(Task.CompletedTask); // Return true to indicate successful update

            // Mock DeleteAsync method
            mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<PLCategory>()))
                .Returns(Task.CompletedTask); // Return true to indicate successful deletion
            //Mock IsUnique
            mockRepo.Setup(r => r.IsPLCategoryDescriptionUnique(It.IsAny<string>()))
              .ReturnsAsync((string description) => {
                  return !plCategories.Any(q => q.Description == description);
              });

            return mockRepo;
        }
    }
}
