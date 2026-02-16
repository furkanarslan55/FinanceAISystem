using FinanceAI.Application.Features.Debts;
using FinanceAI.Business.Features.Incomes;

namespace FinanceAI.Application.Features.Incomes
{
    public interface IIncomeService
    {
        Task<List<IncomeDto>> GetAllByCurrentUserAsync();
        Task CreateAsync(IncomeCreateDto dto);

        Task Delete(int id);
        Task Update (IncomeUpdateDto dto);

        Task <IncomeDto> GetByIdWithCategoryAsync(int id);
        Task<IncomeDto?> GetLastIncomeAsync();
    }
}
