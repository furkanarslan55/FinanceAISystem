using FinanceAI.Core.Common;
using FinanceAI.Core.Entities.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities.DebtEntity
{
    public class DebtCategory :BaseEntity
    {


        public string Name { get; set; }
        public string Description { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Debt> Debts { get; set; } = new List<Debt>();  //bir kategorinin birden fazla borcu olabilir






    }
}
