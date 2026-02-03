using AutoMapper;
using FinanceAI.Application.Features.VariableCost.VariableCostService;
using FinanceAI.Application.Features.VariableCosts.VariableCostCategoryService;
using FinanceAI.Application.Features.VariableCosts.VariableCostServices;
namespace FinanceAI.Application.Features.VariableCosts
{
    public class Mapping:Profile
    {

        public Mapping()
        { 
        CreateMap<CreatVariableCostDto, Core.Entities.VariableCostEntity.VariablesCosts>();
            CreateMap<UpdateVariableCostDto, Core.Entities.VariableCostEntity.VariablesCosts>();
            CreateMap<VariableCategoryCreateDto, Core.Entities.VariableCostEntity.VariableCostCategory>();
        }


    }
}
