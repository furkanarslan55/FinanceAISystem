using FinanceAI.Application.Features.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.Debts
{
    public interface IDebtCategoryServices
    {
        Task<List<DebtCategoryDto>> GetAllByUserIdAsync();
        Task CreateAsync(DebtCategoryCreateDto dto);
        Task UpdateAsync(DebtCategoryUpdateDto dto);
        Task DeleteAsync(int id);






    }
}
