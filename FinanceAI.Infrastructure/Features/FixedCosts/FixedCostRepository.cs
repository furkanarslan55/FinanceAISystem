using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Entities.FixedCostEntity   ;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceAI.Infrastructure.Features.FixedCosts
{
    public class FixedCostRepository :GenericRepository<FixedCost> , IFixedCostRepository
    {

        private readonly AppDbContext _context;
        public FixedCostRepository(AppDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task<List<FixedCost>> GetFixedCostWithCategoriesAsync(int userId)
        {
            return await _context.FixedCosts
                 .Include(x => x.FixedCostCategory)
                 .Where(x => x.AppUserId == userId)
                 .ToListAsync();
        }

        public async Task<FixedCost> GetFixedCostWithCategoryByIdAsync(int fixedCostId)
        {
            return await _context.FixedCosts
                  .Include(x => x.FixedCostCategory)
                  .FirstOrDefaultAsync(x => x.Id == fixedCostId);
        }
    }
}
