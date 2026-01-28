using FinanceAI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities
{
    public class DebtCategory : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // Örn: "Banka Kredisi", "Kredi Kartı", "Eğitim", "Diğer"
        public string? Description { get; set; }

        // İlişki: Bir kategoride birden fazla borç olabilir
        public ICollection<Debt> Debts { get; set; } = new List<Debt>();
    }
}
