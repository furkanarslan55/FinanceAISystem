using UI.Models.ViewModel.Income;

namespace UI.Services.Income
{
    public interface IIncomeService
    {
        Task<List<IncomeDto>> GetAllAsync();
        Task<bool> CreateAsync(IncomeCreateDto dto);
    }
}
