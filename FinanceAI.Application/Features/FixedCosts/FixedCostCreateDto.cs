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
        public string Description { get; set; }

        public int FixedCategoryId { get; set; }


    }
}
