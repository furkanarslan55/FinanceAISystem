using FinanceAI.Application.Features.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.FixedCosts
{
    public interface IFixedCostCategoryService
    {
        Task<List<FixedCostCategoryViewDto>> GetAllByUserIdAsync();
        Task CreateAsync(FixedCostCategoryCreateDto dto);
        Task UpdateAsync( FixedCostCategoryUpdateDto dto);
        Task DeleteAsync(int id);

       
    }
}
