using FinanceAI.Core.Common;
using FinanceAI.Core.Entities.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities.VariableCostEntity
{
    public class VariablesCosts :BaseEntity
    {

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public int VariableCostCategoryId { get; set; }
        public VariableCostCategory VariableCostCategory { get; set; } = null!;

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

    }
}
