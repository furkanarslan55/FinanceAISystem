using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities.FixedCostEntity
{
    public interface IFixedCostRepository :IGenericRepository<FixedCost>
    {

        Task<List<FixedCost>> GetFixedCostWithCategoriesAsync(int userId);
        Task<FixedCost> GetFixedCostWithCategoryByIdAsync(int fixedCostId);



    }
}
