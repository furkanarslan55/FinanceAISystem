using AutoMapper;
using FinanceAI.Core.Entities.FixedCostEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.FixedCosts
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<FixedCostCreateDto, FixedCost>();

            CreateMap<FixedCostCategory, FixedCostCategoryViewDto>().ReverseMap();

            CreateMap<FixedCostCategoryCreateDto, FixedCostCategory>();

            CreateMap<FixedCostCategoryUpdateDto, FixedCostCategory>();

            CreateMap<FixedCost, FixedCostDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.FixedCostCategory.Name))
                .ReverseMap();
        }
    }
}
