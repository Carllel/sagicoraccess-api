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

namespace Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetails
{
    public class GetPLCategoryDetailsQueryHandler : IRequestHandler<GetPLCategoryDetailsQuery, 
        PLCategoryDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IPLCategoryRepository _pLCategoryRepository;
        private readonly IAppLogger<GetPLCategoryDetailsQueryHandler> _logger;

        public GetPLCategoryDetailsQueryHandler(IMapper mapper, 
            IPLCategoryRepository pLCategoryRepository,
            IAppLogger<GetPLCategoryDetailsQueryHandler> logger)
        {
            this._mapper = mapper;
            this._pLCategoryRepository = pLCategoryRepository;
            this._logger = logger;
        }
        public async Task<PLCategoryDetailsDto> Handle(GetPLCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var pLCategory = await _pLCategoryRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (pLCategory == null)
                throw new NotFoundException(nameof(PLCategory), request.Id);

            // convert data object to DTO object
            var data = _mapper.Map<PLCategoryDetailsDto>(pLCategory);

            // return DTO object
            _logger.LogInformation($"PL Category was retrieved successfully using Id '{request.Id}'");
            return data;
        }
    }
}
