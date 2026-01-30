using FinanceAI.Core.Common;
using FinanceAI.Core.Entities.AppUserEntity;
using FinanceAI.Core.Entities.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities
{
    public class Income : BaseEntity
    {
        public string Description { get; set; } = string.Empty; // Örn: "Ocak Maaşı"
        public decimal Amount { get; set; }
        public DateTime IncomeDate { get; set; } // Gelirin girdiği tarih

        // İlişki: Gelir Kategorisi
        public int IncomeCategoryId { get; set; }
        public IncomeCategory IncomeCategory { get; set; } = null!;

        // Anayasa: Kullanıcı İzolasyonu
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }
}
