using FinanceAI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; } // Gelir mi Gider mi?
        public string Category { get; set; } = "Genel"; // Mutfak, Ulaşım, Teknoloji vb.

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }

    public enum TransactionType
    {
        Income = 1, // Gelir
        Expense = 2  // Gider
    }
}
