using FinanceAI.Core.Common;
using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Entities.FixedCostEntity;
using FinanceAI.Core.Entities.Incomes;


namespace FinanceAI.Core.Entities.AppUserEntity
{
    public class AppUser : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public decimal MonthlyIncome { get; set; }
        public decimal TotalDebtAmount { get; set; }

        public ICollection<Income> Incomes { get; set; } = new List<Income>();
        public ICollection<IncomeCategory> IncomeCategories { get; set; } = new List<IncomeCategory>();

        public ICollection<FixedCost> FixedCosts { get; set; } = new List<FixedCost>();

        public ICollection<FixedCostCategory> FixedCostCategories { get; set; }
            = new List<FixedCostCategory>();

        public ICollection<DebtCategory> DebtCategories { get; set; } 
            = new List<DebtCategory>();

        public ICollection<Debt> Debts { get; set; } = new List<Debt>();
    }
}
