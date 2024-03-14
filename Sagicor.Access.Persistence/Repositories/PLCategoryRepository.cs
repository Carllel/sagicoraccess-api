using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Domain.Entities;

namespace Sagicor.Access.Persistence.Repositories
{
    public class PLCategoryRepository : GenericRepository<PLCategory>, IPLCategoryRepository
    {
        public PLCategoryRepository(SagicorAccessDbContext context) : base(context) { }
 
        public async Task<PLCategory> GetPLCategoryByCodeAsync(string code)
        {
            var plCategory = await _context.PLCategories
                .FirstOrDefaultAsync(q => q.Code == code);

            return plCategory;
        }

        public async Task<bool> IsPLCategoryDescriptionUnique(string description)
        {
            return await _context.PLCategories.AnyAsync(q => q.Description == description) == false;
        }
    }
}
