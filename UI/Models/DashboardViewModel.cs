using FinanceAI.Application.Features.Debts;
using FinanceAI.Business.Features.Incomes;
using UI.Models.FixedCost;


namespace UI.Models;
public class DashboardViewModel
{
    public DebtDto? LastDebt { get; set; }
    public IncomeDto? LastIncome { get; set; }
    public FixedCostDto? LastFixedCost { get; set; }
}