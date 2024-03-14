using AutoMapper;
using MediatR;
using Sagicor.Access.Application.Contracts.Logging;
using Sagicor.Access.Application.Contracts.Persistence;
using Sagicor.Access.Application.Exceptions;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetailsByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetails
{
    public class GetPLCategoryDetailsByCodeQueryHandler : IRequestHandler<GetPLCategoryDetailsByCodeQuery, PLCategoryDetailsByCodeDto>
    {
        private readonly IMapper _mapper;
        private readonly IPLCategoryRepository _pLCategoryRepository;
        private readonly IAppLogger<GetPLCategoryDetailsByCodeQueryHandler> _logger;

        public GetPLCategoryDetailsByCodeQueryHandler(IMapper mapper, 
            IPLCategoryRepository pLCategoryRepository, 
            IAppLogger<GetPLCategoryDetailsByCodeQueryHandler> logger)
        {
            this._mapper = mapper;
            this._pLCategoryRepository = pLCategoryRepository;
            this._logger = logger;
        }

        public async Task<PLCategoryDetailsByCodeDto> Handle(GetPLCategoryDetailsByCodeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var pLCategory = await _pLCategoryRepository.GetPLCategoryByCodeAsync(request.Code);

            // verify that record exists
            if (pLCategory == null)
                throw new NotFoundException(nameof(PLCategory), request.Code);

            // convert data object to DTO object
            var data = _mapper.Map<PLCategoryDetailsByCodeDto>(pLCategory);

            // return DTO object
            _logger.LogInformation($"PL Category was retrieved successfully using code '{request.Code}'");
            return data;
        }
    }
}
