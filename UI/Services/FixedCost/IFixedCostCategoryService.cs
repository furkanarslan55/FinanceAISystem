using UI.Models.FixedCost.FixedCostCategory;

namespace UI.Services.FixedCost
{
    public interface IFixedCostCategoryService
    {
        Task<List<FixedCostCategoryViewDto>> GetAllByUserIdAsync();
        Task CreateAsync(FixedCostCategoryCreateDto dto);
        Task UpdateAsync(FixedCostCategoryUpdateDto dto);
        Task DeleteAsync(int id);
        Task<FixedCostCategoryViewDto> GetByWithId(int id);

    }
}
