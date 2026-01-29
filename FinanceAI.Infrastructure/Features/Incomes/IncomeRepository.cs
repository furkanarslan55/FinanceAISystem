using FinanceAI.Core.Entities;
using FinanceAI.Core.Entities.Incomes;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Features.Incomes
{
    public class IncomeRepository : GenericRepository<Income>, IIncomeRepository
    {
        private readonly AppDbContext _context;

        public IncomeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Income>> GetIncomesWithCategoriesAsync(int userId)
        {
            // "Sadece giriş yapan kullanıcının verisi" kuralına uygun filtreleme
            return await _context.Incomes
                .Include(x => x.IncomeCategory)
                .Where(x => x.AppUserId == userId)
                .ToListAsync();
        }
    }
}
