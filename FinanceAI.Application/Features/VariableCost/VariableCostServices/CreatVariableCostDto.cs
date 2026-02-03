using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.VariableCosts.VariableCostServices
{
    public class CreatVariableCostDto
    {

        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int VariableCostCategoryId { get; set; }
    }
}
