
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.FixedCosts
{
    public interface IFixedCostService
    {


   
        Task CreateAsync(FixedCostCreateDto dto);
        Task UpdateAsync( int id,FixedCostUpdateDto dto);
        Task DeleteAsync(int id);

        Task<List<FixedCostDto>> GetAllWithCategoryAsync();

        Task<FixedCostDto> GetByIdWithCategoryAsync(int id);
        Task<FixedCostDto> GetLastFixedCostAsync();


    }
}
