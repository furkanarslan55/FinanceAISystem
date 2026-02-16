using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.Debts
{
    public interface IDebtServices 
    {
        Task<List<DebtDto>> GetAllByUserIdAsync();

        Task CreateAsync(DebtCreateDto dto);
        Task UpdateAsync(DebtUpdateDto dto);

        Task DeleteAsync(int id);

        Task <DebtDto> GetDebtWithCategoryByIdAsync(int debtId);

        Task<DebtDto?> GetLastDebtAsync();


    }
}
