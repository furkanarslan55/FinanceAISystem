using FinanceAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<List<Transaction>> GetLastTransactionsByUserIdAsync(int userId, int count);
        Task<decimal> GetMonthlyTotalExpenseAsync(int userId, int month, int year);
    }
}
