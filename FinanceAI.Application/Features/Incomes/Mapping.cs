using AutoMapper;
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
        }
    }
}
