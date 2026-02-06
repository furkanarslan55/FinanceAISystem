using UI.Models.Debt;

namespace UI.Services.Debt
{
    public interface IDebtCategoryService
    {

        Task<List<DebtCategoryDto>> GetAllByUserIdAsync();
        Task CreateAsync(DebtCategoryCreateDto dto);
        Task UpdateAsync(DebtCategoryUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
