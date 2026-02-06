using UI.Models.Debt;

namespace UI.Services.Debt
{
    public interface IDebtService
    {

        Task<List<DebtViewDto>> DebtAllWithCategories();
        Task CreateDebt(DebtCreateDto dto);
        Task DeleteDebt(int id);


    }
}
