using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceAI.Infrastructure.Features.Debts
{
    public class DebtRepository :GenericRepository<Debt>, IDebtRepository
    {
        private readonly AppDbContext _context;
        public DebtRepository(AppDbContext context) : base(context)
        {

            _context = context;
        }

        public async Task<List<Debt>> GetDebtWithCategoriesAsync(int userId)
        {
            return await _context.Debts
                  .Include(x => x.DebtCategory)
                  .Where(x => x.AppUserId == userId)
                  .ToListAsync();
        }
    }
}
