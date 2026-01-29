using FinanceAI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities.Incomes
{
    public class IncomeCategory : BaseEntity
    {
       
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // Güvenlik: Bu kategori hangi kullanıcıya ait?
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

        // İlişki: Bir kategoride birden fazla gelir kaydı olabilir.
        public ICollection<Income> Incomes { get; set; } = new List<Income>();
    }
}
