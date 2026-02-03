using FinanceAI.Core.Entities.VariableCostEntity;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;

namespace FinanceAI.Infrastructure.Features.VariableCosts
{
    public class VariableCostRepository :GenericRepository<VariablesCosts> , IVariableCostRepository
    {
        
        public VariableCostRepository(AppDbContext dbContext) : base(dbContext)
        {
           

        }


    }
}
