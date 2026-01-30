using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Features.Debts
{
    public class DebtCategoryRepository :GenericRepository<DebtCategory>, IDebtCategoryRepository
    {

        private readonly AppDbContext _context;

        public DebtCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



    }
}
