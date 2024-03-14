using Microsoft.AspNetCore.Components;
using Sagicor.Access.Api.AdminUI.Contracts;
using Sagicor.Access.Api.AdminUI.Models.PLCategory;

namespace Sagicor.Access.Api.AdminUI.Pages.PLCategories
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IPLCategoryService PLCategoryService { get; set; }
   
        //[Inject]
        //IToastService toastService { get; set; }
        public List<PLCategoryVM> PLCategories { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected void CreatePLCategory()
        {
            NavigationManager.NavigateTo("/plcategories/create/");
        }

        protected void EditPLCategory(Guid id)
        {
            NavigationManager.NavigateTo($"/plcategories/edit/{id}");
        }

        protected void DetailsPLCategory(Guid id)
        {
            NavigationManager.NavigateTo($"/plcategories/details/{id}");
        }

        protected async Task DeletePLCategory(Guid id)
        {
            var response = await PLCategoryService.DeletePLCategory(id);
            if (response.Success)
            {
                //toastService.ShowSuccess("PL Category deleted Successfully");
                await OnInitializedAsync();
            }
            else
            {
                Message = response.Message;
            }
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    PLCategories = await PLCategoryService.GetPLCategoriesAsync();
        //}
    }
}