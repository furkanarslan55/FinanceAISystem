using FinanceAI.Core.Entities.FixedCostEntity;
using FinanceAI.Core.Entities.FixedCostsEntity;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Features.FixedCosts
{
    public class FixedCostCategoryRepository : GenericRepository<FixedCostCategory>, IFixedCostCategoryRepository
    {
        public FixedCostCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
