using UI.Models.Incomes;

namespace UI.Services.Incomes
{
    public interface IIncomeCategoryService
    {
        Task<List<IncomeCategoryViewDto>> GetAllAsync();
        Task CreateAsync(IncomeCategoryCreateDto dto);
        Task UpdateAsync(IncomeCategoryUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
