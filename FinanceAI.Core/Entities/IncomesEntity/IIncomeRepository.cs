using FinanceAI.Core.Entities;
using FinanceAI.Core.Entities.Incomes;
using FinanceAI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Features.Incomes
{
    public interface IIncomeRepository : IGenericRepository<Income>
    {
        // İleride sadece gelirlere özel (örneğin kategoriyle birlikte getir gibi) 
        // metodlar buraya eklenecek.
        Task<List<Income>> GetIncomesWithCategoriesAsync(int userId);
        Task<Income> GetIncomeWithCategorybyIdAsync(int id);
    }
}
