using FinanceAI.Core.Entities.VariableCostEntity;
using FinanceAI.Infrastructure.Context;
using FinanceAI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Features.VariableCosts
{
    public class VariableCostCategoryRepository : GenericRepository<VariableCostCategory>, IVariableCostCategoryRepository
    {


            public VariableCostCategoryRepository(AppDbContext context) : base(context)
            {

             }


    }
}
