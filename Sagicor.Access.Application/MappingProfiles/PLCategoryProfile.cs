using AutoMapper;
using Sagicor.Access.Application.Features.PLCategory.Commands.CreatePLCategory;
using Sagicor.Access.Application.Features.PLCategory.Commands.UpdatePLCategory;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetAllPLCategories;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetails;
using Sagicor.Access.Application.Features.PLCategory.Queries.GetPLCategoryDetailsByCode;
using Sagicor.Access.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.MappingProfiles
{
    public class PLCategoryProfile : Profile
    {
        public PLCategoryProfile() 
        {
            CreateMap<PLCategoryDto, PLCategory>().ReverseMap();
            CreateMap<PLCategory, PLCategoryDetailsDto>();
            CreateMap<PLCategory, PLCategoryDetailsByCodeDto>();
            CreateMap<CreatePLCategoryCommand, PLCategory>();
            CreateMap<UpdatePLCategoryCommand, PLCategory>();
        }
    }
}
