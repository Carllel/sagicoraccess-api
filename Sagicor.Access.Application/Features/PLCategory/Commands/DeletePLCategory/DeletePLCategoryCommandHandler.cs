using MediatR;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Commands.DeletePLCategory
{
    public class DeletePLCategoryCommandHandler : IRequestHandler<DeletePLCategoryCommand, Unit>
    {
        private readonly IPLCategoryRepository _pLCategoryRepository;

        public DeletePLCategoryCommandHandler(IPLCategoryRepository pLCategoryRepository)
        {
            this._pLCategoryRepository = pLCategoryRepository;
        }
        public async Task<Unit> Handle(DeletePLCategoryCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var plCategoryToDelete = await _pLCategoryRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (plCategoryToDelete == null)
                throw new NotFoundException(nameof(PLCategory), request.Id);

            // remove from database
            await _pLCategoryRepository.DeleteAsync(plCategoryToDelete);

            // retun record id
            return Unit.Value;
        }
    }
}
