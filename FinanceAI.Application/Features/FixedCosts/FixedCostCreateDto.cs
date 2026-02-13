using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.FixedCosts
{
    public class FixedCostCreateDto
    {

        public string Name { get; set; }
        public decimal Amount { get; set; }
        

        public int FixedCostCategoryId { get; set; }


    }
}
