using Sagicor.Access.Api.AdminUI.Models.PLCategory;
using Sagicor.Access.Api.AdminUI.Services.Base;

namespace Sagicor.Access.Api.AdminUI.Contracts
{
    public interface IPLCategoryService
    {
        Task<List<PLCategoryVM>> GetPLCategoriesAsync();
        Task<PLCategoryVM> GetPLCategoryDetails(Guid id);
        Task<Response<Guid>> CreatePLCategory(PLCategoryVM pLCategory);
        Task<Response<Guid>> UpdatePLCategory(Guid id,PLCategoryVM pLCategory);
        Task<Response<Guid>> DeletePLCategory(Guid id);
    }
}
