using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetailsByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Contracts.InsightWarehouse
{
    public interface IInsightWarehouse
    {
        Task<IReadOnlyList<PLCategoryDetailsByCodeDto>> GetPLCategoryByCodeAsync(string code);
    }
}
