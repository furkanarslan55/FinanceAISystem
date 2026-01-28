using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Dtos.Transaction
{
    public class TransactionCreateDto
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int TransactionType { get; set; } // 1: Gelir, 2: Gider
        public string Category { get; set; } = "Genel";
        public int AppUserId { get; set; }
        public int? DebtId { get; set; }
    }
}
