using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Frontend tarafında ikon veya renk belirlemek için gerekebilir
        public int CategoryType { get; set; }
        public string CategoryTypeName { get; set; } // Örn: "Debt", "Income"

        // Bu kategorinin kullanıcıya mı ait yoksa sistem mi olduğunu anlamak için
        public bool IsCustom { get; set; }
    }
}