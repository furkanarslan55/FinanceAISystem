using FinanceAI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities
{
    public class Debt : BaseEntity
    {
        public string Title { get; set; } = string.Empty; // Örn: "Kredi Kartı", "Öğrenci Borcu"
        public decimal TotalAmount { get; set; } // Toplam miktar
        public decimal RemainingAmount { get; set; } // Kalan miktar
        public decimal InterestRate { get; set; } // Faiz oranı (AI planlaması için kritik)
        public DateTime DueDate { get; set; } // Son ödeme veya bitiş tarihi
        public int Priority { get; set; } // 1: Çok Acil, 5: Düşük (AI bunu kullanacak)

        // İlişki: Bu borç hangi kullanıcıya ait?
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

    
    }
}
