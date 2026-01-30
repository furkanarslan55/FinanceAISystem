using FinanceAI.Core.Entities.FixedCostEntity   ;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;

namespace FinanceAI.Infrastructure.Features.FixedCosts
{
    public class FixedCostRepository :GenericRepository<FixedCost> , IFixedCostRepository
    {

        private readonly AppDbContext _context;
        public FixedCostRepository(AppDbContext context) : base(context)
        {
            _context = context;

        }





    }
}
