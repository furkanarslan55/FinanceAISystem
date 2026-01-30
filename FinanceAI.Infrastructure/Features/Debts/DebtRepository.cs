using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceAI.Infrastructure.Features.Debts
{
    public class DebtRepository :GenericRepository<Debt>, IDebtRepository
    {
        private readonly DbContext _context;
        public DebtRepository(AppDbContext context) : base(context)
        {

            _context = context;
        }




    }
}
