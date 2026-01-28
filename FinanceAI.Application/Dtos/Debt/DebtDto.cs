using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Dtos.Debt
{
    public class DebtDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal RemainingAmount { get; set; }
        public decimal InterestRate { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
