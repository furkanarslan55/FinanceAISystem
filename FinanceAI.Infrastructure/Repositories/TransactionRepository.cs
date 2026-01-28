using FinanceAI.Core.Entities;
using FinanceAI.Core.Interfaces;
using FinanceAI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context) { }

        public async Task<List<Transaction>> GetLastTransactionsByUserIdAsync(int userId, int count)
        {
            return await _context.Transactions
                .Where(x => x.AppUserId == userId)
                .OrderByDescending(x => x.CreatedDate)
                .Take(count)
                .ToListAsync();
        }

        public async Task<decimal> GetMonthlyTotalExpenseAsync(int userId, int month, int year)
        {
            return await _context.Transactions
                .Where(x => x.AppUserId == userId &&
                            x.Type == TransactionType.Expense &&
                            x.CreatedDate.Month == month &&
                            x.CreatedDate.Year == year)
                .SumAsync(x => x.Amount);
        }
    }
}
