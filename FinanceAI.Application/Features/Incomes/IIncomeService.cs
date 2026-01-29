using FinanceAI.Business.Features.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.Incomes
{
    public interface IIncomeService
    {
        Task<List<IncomeDto>> GetAllByCurrentUserAsync();
        Task CreateAsync(IncomeCreateDto dto);
        // İhtiyaca göre Delete ve Update eklenebilir
    }
}
