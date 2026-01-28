using FinanceAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Interfaces
{
    public interface IDebtRepository : IGenericRepository<Debt>
    {
        // Service katmanında filtreleme yapmak yerine buradaki metotları çağıracağız
        Task<List<Debt>> GetDebtsByUserIdWithDetailsAsync(int userId);
        Task<List<Debt>> GetHighPriorityDebtsAsync(int userId);
    }
}
