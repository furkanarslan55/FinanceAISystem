using FinanceAI.Core.Common;
using FinanceAI.Core.Entities.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities.FixedCostEntity
{
    public class FixedCost : BaseEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
       
        public int FixedCostCategoryId { get; set; }
        public FixedCostCategory FixedCostCategory { get; set; } = null!;

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!; // yaşam gideri kullanıcı ilişkisi

    }
}
