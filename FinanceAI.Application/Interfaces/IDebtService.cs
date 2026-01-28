using FinanceAI.Application.Dtos.Debt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Interfaces
{
    public interface IDebtService
    {
        Task<int> CreateDebtAsync(DebtCreateDto dto);
        Task<List<DebtDto>> GetDebtsByUserIdAsync(int userId);
    }
}
