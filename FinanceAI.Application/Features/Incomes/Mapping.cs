using AutoMapper;
using FinanceAI.Business.Features.Incomes;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Entities.Incomes;
namespace FinanceAI.Application.Features.Incomes
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // IncomeCategory <---> IncomeCategoryViewDto
            CreateMap<IncomeCategory, IncomeCategoryViewDto>().ReverseMap();

            // IncomeCategoryCreateDto ----> IncomeCategory
            CreateMap<IncomeCategoryCreateDto, IncomeCategory>();

            // IncomeCategoryUpdateDto ----> IncomeCategory
            CreateMap<IncomeCategoryUpdateDto, IncomeCategory>().ForMember(dest => dest.Id,opt => opt.Ignore());
            CreateMap<Income, IncomeDto>().ReverseMap();
            //CreateMap<IncomeCreateDto, Income>();
                CreateMap<IncomeUpdateDto, Income>().ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
