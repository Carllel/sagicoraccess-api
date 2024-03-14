using AutoMapper;
using Blazored.LocalStorage;
using Sagicor.Access.Api.AdminUI.Contracts;
using Sagicor.Access.Api.AdminUI.Models.PLCategory;
using Sagicor.Access.Api.AdminUI.Services.Base;

namespace Sagicor.Access.Api.AdminUI.Services
{
    public class PLCategoryService : BaseHttpService, IPLCategoryService
    {
        private readonly IMapper _mapper;


        public PLCategoryService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            this._mapper = mapper;
        }

        public async Task<Response<Guid>> CreatePLCategory(PLCategoryVM pLCategory)
        {
            try
            {
                await AddBearerToken();
                var createPLCategoryCommand = _mapper.Map<CreatePLCategoryCommand>(pLCategory);
                await _client.PLCategoriesPOSTAsync(createPLCategoryCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<Guid>(ex);
            }
            throw new NotImplementedException();
        }

        public async Task<Response<Guid>> DeletePLCategory(Guid id)
        {
            try
            {
                await AddBearerToken();
                await _client.PLCategoriesDELETEAsync(id);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<List<PLCategoryVM>> GetPLCategoriesAsync()
        {
            await AddBearerToken();
            var plCategories = await _client.PLCategoriesAllAsync();
            return _mapper.Map<List<PLCategoryVM>>(plCategories);
            throw new NotImplementedException();
        }


        public async Task<PLCategoryVM> GetPLCategoryDetails(Guid id)
        {
            await AddBearerToken();
            var plCategory = await _client.GetByIdAsync(id);
            return _mapper.Map<PLCategoryVM>(plCategory);
        }

        public async Task<Response<Guid>> UpdatePLCategory(Guid id, PLCategoryVM pLCategory)
        {
            try
            {
                await AddBearerToken();
                var updatePLCategoryCommand = _mapper.Map<UpdatePLCategoryCommand>(pLCategory);
                await _client.PLCategoriesPUTAsync(id.ToString(), updatePLCategoryCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<Guid>(ex);
            }
            throw new NotImplementedException();
        }
    }
}
