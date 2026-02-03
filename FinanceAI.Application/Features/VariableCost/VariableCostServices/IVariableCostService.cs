using FinanceAI.Application.Features.VariableCosts.VariableCostServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.VariableCost.VariableCostService
{
    public interface IVariableCostService
    {


        Task<List<VariableCostViewDto>> GetAllByIdVariableCost();
        Task CreateVariableCost(CreatVariableCostDto dto);
        Task UpdateVariableCost(UpdateVariableCostDto dto);

        Task DeleteVariableCost(int id);


    }
}
