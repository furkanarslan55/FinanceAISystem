using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.Incomes
{
    public interface IIncomeCategoryService
    {
        Task<List<IncomeCategoryViewDto>> GetAllByUserIdAsync();
        Task CreateAsync(IncomeCategoryCreateDto dto);
        Task UpdateAsync(IncomeCategoryUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
