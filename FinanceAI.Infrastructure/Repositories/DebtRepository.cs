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
    public class DebtRepository : GenericRepository<Debt>, IDebtRepository
    {
        public DebtRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Debt>> GetDebtsByUserIdWithDetailsAsync(int userId)
        {
            // Sorgu SQL seviyesinde (database'de) çalışır, performansı korur.
            return await _context.Debts
           
                .Where(x => x.AppUserId == userId && !x.IsDeleted)
                .OrderByDescending(x => x.InterestRate) // En yüksek faizli olanı başa alalım (AI için hazırlık)
                .ToListAsync();
        }

        public async Task<List<Debt>> GetHighPriorityDebtsAsync(int userId)
        {
            return await _context.Debts
                .Where(x => x.AppUserId == userId && x.Priority >= 3)
                .ToListAsync();
        }
    }
}
