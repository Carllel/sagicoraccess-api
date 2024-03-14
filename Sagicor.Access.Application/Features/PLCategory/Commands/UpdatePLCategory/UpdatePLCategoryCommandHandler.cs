using AutoMapper;
using MediatR;
using Sagicor.Access.Application.Contracts.Logging;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Commands.UpdatePLCategory
{
    internal class UpdatePLCategoryCommandHandler : IRequestHandler<UpdatePLCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPLCategoryRepository _pLCategoryRepository;
        private readonly IAppLogger<UpdatePLCategoryCommandHandler> _logger;

        public UpdatePLCategoryCommandHandler(IMapper mapper, 
            IPLCategoryRepository pLCategoryRepository,
            IAppLogger<UpdatePLCategoryCommandHandler> logger)
        {
            this._mapper = mapper;
            this._pLCategoryRepository = pLCategoryRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdatePLCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new UpdatePLCategoryCommandValidator(_pLCategoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(PLCategory), request.Id);
                throw new BadRequestException("Invalid PL Category", validationResult);
            }

            // convert to domain entity object
            var plCategoryToUpdate = _mapper.Map<Domain.Entities.PLCategory>(request);

            // add to database
            await _pLCategoryRepository.UpdateAsync(plCategoryToUpdate);

            // return Unit value
            _logger.LogInformation("PL Category was updated successfully");
            return Unit.Value;
        }
    }
}
