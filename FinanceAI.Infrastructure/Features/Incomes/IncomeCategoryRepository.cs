using FinanceAI.Core.Entities.Incomes;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Features.Incomes
{
    public class IncomeCategoryRepository : GenericRepository<IncomeCategory>, IIncomeCategoryRepository
    {
        public IncomeCategoryRepository(AppDbContext context) : base(context)
        {
        
        }
    }
}
