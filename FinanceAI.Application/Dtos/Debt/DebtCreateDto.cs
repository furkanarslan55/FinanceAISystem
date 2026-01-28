using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Dtos.Debt
{
    public class DebtCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal InterestRate { get; set; } // Örn: 3.5 (Yüzde olarak)
        public DateTime DueDate { get; set; }
        public int Priority { get; set; } // 1: Düşük, 3: Yüksek
        public int AppUserId { get; set; } // Borcun sahibi

        public int DebtCategoryId { get; set; }
        // Kullanıcı "Diğer" seçerse dolduracağı alan:
        public string? OtherCategoryDescription { get; set; }
    }
}
