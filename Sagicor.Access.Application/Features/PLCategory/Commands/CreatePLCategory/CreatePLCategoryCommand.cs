using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Commands.CreatePLCategory
{
    public class CreatePLCategoryCommand : IRequest<Guid>
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
