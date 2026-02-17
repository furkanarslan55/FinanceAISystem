using FinanceAI.Application.Features.Debts;
using FinanceAI.Application.Features.FixedCosts;
using FinanceAI.Business.Features.Incomes;

namespace FinanceAI.Application.Features.Dashboard
{
    public class DashboardViewModel
    {
        public DebtDto? LastDebt { get; set; }
        public IncomeDto? LastIncome { get; set; }
        public FixedCostDto? LastFixedCost { get; set; }
       
    }
}
