using UI.Models.ViewModel.Income;

namespace UI.Services.Income
{
    public interface IIncomeCategoryService
    {
        Task<List<IncomeCategoryViewDto>> GetAllAsync();
        Task CreateAsync(IncomeCategoryCreateDto model);
        Task UpdateAsync(IncomeCategoryUpdateDto model);
        Task DeleteAsync(int id);
    }
}
