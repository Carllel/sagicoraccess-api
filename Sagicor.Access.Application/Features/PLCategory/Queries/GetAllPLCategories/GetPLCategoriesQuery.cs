using MediatR;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetAllPLCategories;

namespace Sagicor.Access.Application.Features.PLCategory.Queries.GetAllPLCategories
{
    public record GetPLCategoriesQuery : IRequest<List<PLCategoryDto>>;
}
