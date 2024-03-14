using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetails;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetailsByCode;
using Sagicor.Access.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Contracts.Persistence
{
    public interface IPLCategoryRepository : IGenericRepository<PLCategory>
    {
        Task<bool> IsPLCategoryDescriptionUnique(string description);
        Task<PLCategory> GetPLCategoryByCodeAsync(string code);
    }
}
