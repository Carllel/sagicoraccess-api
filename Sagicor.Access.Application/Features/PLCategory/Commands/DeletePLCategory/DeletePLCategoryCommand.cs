using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Commands.DeletePLCategory
{
    public class DeletePLCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
