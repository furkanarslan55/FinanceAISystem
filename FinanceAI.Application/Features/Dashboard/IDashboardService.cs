using FinanceAI.Core.GenericInterfaces;

namespace FinanceAI.Application.Features.Dashboard
{
    public interface IDashboardService
    {
        Task<List<CurrencyDto>> GetDashboardRatesAsync();
    }
}
