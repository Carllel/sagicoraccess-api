using MediatR;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetailsByCode
{
    //public class GetPLCategoryDetailsByCodeQuery : IRequest<PLCategoryDetailsByCodeDto>
    //{
    //    public string Code { get; set; }
    //}
    public record GetPLCategoryDetailsByCodeQuery(string Code) : IRequest<PLCategoryDetailsByCodeDto>;
}
