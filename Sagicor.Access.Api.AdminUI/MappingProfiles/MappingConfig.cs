using AutoMapper;
using Sagicor.Access.Api.AdminUI.Models.PLCategory;
using Sagicor.Access.Api.AdminUI.Services.Base;

namespace Sagicor.Access.Api.AdminUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<PLCategoryDto, PLCategoryVM>().ReverseMap();
            CreateMap<PLCategoryDetailsDto, PLCategoryVM>().ReverseMap();
            CreateMap<CreatePLCategoryCommand, PLCategoryVM>().ReverseMap();
            CreateMap<UpdatePLCategoryCommand, PLCategoryVM>().ReverseMap();


            //CreateMap<EmployeeVM, Employee>().ReverseMap();

        }
    }
}
