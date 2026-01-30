using FinanceAI.Core.Common;
using FinanceAI.Core.Entities.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities.DebtEntity
{
    public class Debt :BaseEntity
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }

        public string Description { get; set; }

        public int DebtCategoryId { get; set; }

        public DebtCategory DebtCategory { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }




    }
}
