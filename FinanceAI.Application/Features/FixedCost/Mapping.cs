using AutoMapper;
using FinanceAI.Core.Entities.FixedCostEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.FixedCost
{
    public class Mapping : Profile
    {
        public Mapping()
        {

            CreateMap<FixedCostCategory, FixedCostCategoryViewDto>().ReverseMap();

            CreateMap<FixedCostCategoryCreateDto, FixedCostCategory>();

            CreateMap<FixedCostCategoryUpdateDto, FixedCostCategory>();
        }
    }
}
