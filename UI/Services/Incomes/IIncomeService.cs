using UI.Models.Incomes;

namespace UI.Services.Incomes
{
    public interface IIncomeService
    {
        Task<List<IncomeViewDto>> GetAllByCurrentUserAsync();
        Task CreateAsync(IncomeCreateDto dto);
        Task Delete(int id);

        Task Update(IncomeUpdateDto dto);
        Task <IncomeViewDto> GetByIdAsync(int id);
    }
}
