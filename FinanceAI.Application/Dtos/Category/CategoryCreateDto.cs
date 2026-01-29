using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FinanceAI.Application.Dtos.Category
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }

        // Kullanıcı bu kategoriyi ne için oluşturuyor? 
        // 1: Debt, 2: Income, 3: FixedCost vb.
        public int CategoryType { get; set; }
    }
}