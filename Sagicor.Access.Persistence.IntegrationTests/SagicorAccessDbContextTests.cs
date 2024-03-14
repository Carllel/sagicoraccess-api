using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sagicor.Access.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Persistence.IntegrationTests
{
    public class SagicorAccessDbContextTests
    {
     
        private SagicorAccessDbContext _sagicorDbContext;

        public SagicorAccessDbContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<SagicorAccessDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _sagicorDbContext = new SagicorAccessDbContext(dbOptions);
        }


        [Fact]
        public void SagicorAccessDbContext_Should_Connect_To_Database()
        {
            // Arrange 
            var optionsBuilder = new DbContextOptionsBuilder<SagicorAccessDbContext>()
                .UseSqlServer("Server=SLJWDSQLRDW1\\DEV;Database=SagicorBankAccess;user id=sbaccessadmin;password=Password1;MultipleActiveResultSets=true;trustServerCertificate=true");

            SagicorAccessDbContext dbContext = new SagicorAccessDbContext(optionsBuilder.Options);
            bool expected = true;

            // Act
            bool result = dbContext.Database.CanConnect();

            // Assert
            Assert.Equal(expected, result);
        }


        [Fact]
        public async void SaveChanges_ShouldSaveNewPLCategory() 
        {
            // Arrange
            var pLCategory = new PLCategory
                {
                    Id = Guid.NewGuid(),
                    Code = "52900",
                    Description = $"Test PL Category 1"
                };

            // Act
            await _sagicorDbContext.PLCategories.AddAsync(pLCategory);
            await _sagicorDbContext.SaveChangesAsync();

            var getNewPLCategory = _sagicorDbContext.PLCategories.FirstOrDefault();


            // Assert
            getNewPLCategory.ShouldNotBeNull();

        }
    }
}
