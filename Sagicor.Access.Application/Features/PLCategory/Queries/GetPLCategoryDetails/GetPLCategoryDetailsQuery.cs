using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetails
{
    //public class GetPLCategoryDetailsQuery : IRequest<PLCategoryDetailsDto>
    //{
    //    public Guid Id { get; set; }
    //}
    public record GetPLCategoryDetailsQuery(Guid Id) : IRequest<PLCategoryDetailsDto>;
}
