
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.FixedCosts
{
    public interface IFixedCostService
    {


        Task<FixedCostDto> CreateAsync(FixedCostCreateDto dto);
        Task<IEnumerable<FixedCostDto>> GetAllAsync();

        Task<FixedCostDto> GetByIdAsync(int id);


    }
}
