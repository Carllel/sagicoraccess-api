using AutoMapper;
using MediatR;
using Sagicor.Access.Application.Contracts.Logging;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Application.Exceptions;
using Sagicor.Access.Application.Features.PLCategory.Commands.UpdatePLCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Commands.CreatePLCategory
{
    public class CreatePLCategoryCommandHandler : IRequestHandler<CreatePLCategoryCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IPLCategoryRepository _pLCategoryRepository;
        private readonly IAppLogger<CreatePLCategoryCommandHandler> _logger;

        public CreatePLCategoryCommandHandler(IMapper mapper, 
            IPLCategoryRepository pLCategoryRepository,
            IAppLogger<CreatePLCategoryCommandHandler> logger)
        {
            this._mapper = mapper;
            this._pLCategoryRepository = pLCategoryRepository;
            this._logger = logger;
        }
        public async Task<Guid> Handle(CreatePLCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreatePLCategoryCommandValidator(_pLCategoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid PL Category", validationResult);

            // convert to domain entity object
            var plCategoryToCreate = _mapper.Map<Domain.Entities.PLCategory>(request);
            // add to database
            await _pLCategoryRepository.CreateAsync(plCategoryToCreate);

            // retun record id
            _logger.LogInformation("PL Category was created successfully");
            return plCategoryToCreate.Id;
        }
    }
}
