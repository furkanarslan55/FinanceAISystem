using FinanceAI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities
{
    public class Category : BaseEntity // Eskiden DebtCategory idi
    {
        public string Name { get; set; }

        // Kullanıcıya özel kategori desteği
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // Kategorinin tipi (Borç, Gider, Gelir vb.)
        // Bu sayede AI hangi verinin ne olduğunu daha iyi anlar.
        public CategoryType Type { get; set; }
    }

    public enum CategoryType
    {
        Debt = 1,      // Borçlar için
        Expense = 2,   // Yaşam giderleri ve harcamalar için
        Income = 3     // Gelir kaynakları için
    }
}
