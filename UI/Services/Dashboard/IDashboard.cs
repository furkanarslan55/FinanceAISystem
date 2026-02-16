using UI.Models;

namespace UI.Services.Dashboard
{
    public interface IDashboard
    {
        Task<DashboardViewModel> GetDashboardSummaryAsync();
    }
}
