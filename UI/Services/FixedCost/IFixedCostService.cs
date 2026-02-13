using UI.Models.FixedCost;

namespace UI.Services.FixedCost
{
    public interface IFixedCostService
    {


        Task CreateAsync(FixedCostCreateDto dto);
        Task UpdateAsync(int id, FixedCostUpdateDto dto);
        Task DeleteAsync(int id);

        Task<List<FixedCostDto>> GetAllWithCategoryAsync();

        Task<FixedCostDto> GetByIdWithCategoryAsync(int id);



    }
}
