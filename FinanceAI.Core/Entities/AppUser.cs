using FinanceAI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities
{
    public class AppUser : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // Güvenlik için

        // Finansal özet (AI için hızlı erişim verisi)
        public decimal MonthlyIncome { get; set; } // Aylık toplam gelir
        public decimal TotalDebtAmount { get; set; } // Toplam borç yükü

        // Navigation Properties (İlişkiler)
        // Bir kullanıcının birden fazla borcu ve harcaması olabilir.
        public ICollection<Debt> Debts { get; set; } = new List<Debt>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>(); // değerin null olmaması için null! kullanmadım, boş liste atadım.
    }
}
