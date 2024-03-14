using AutoMapper;
using MediatR;
using Sagicor.Access.Application.Contracts.Logging;
using Sagicor.Access.Application.Contracts.Persistence;

namespace Sagicor.Access.Application.Features.PLCategory.Queries.GetAllPLCategories
{
    public class GetPLCategoriesQueryHandler : IRequestHandler<GetPLCategoriesQuery, List<PLCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPLCategoryRepository _pLCategoryRepository;
        private readonly IAppLogger<GetPLCategoriesQueryHandler> _logger;

        public GetPLCategoriesQueryHandler(IMapper mapper,
            IPLCategoryRepository pLCategoryRepository,
            IAppLogger<GetPLCategoriesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._pLCategoryRepository = pLCategoryRepository;
            this._logger = logger;
        }


        public async Task<List<PLCategoryDto>> Handle(GetPLCategoriesQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveTypes = await _pLCategoryRepository.GetAsync();

            // convert data objects to DTO objects
            var data = _mapper.Map<List<PLCategoryDto>>(leaveTypes);

            // return list of DTO object
            _logger.LogInformation("PL Categories were retrieved successfully");
            return data;
        }
    }
}
