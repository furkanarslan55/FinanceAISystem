using FinanceAI.Core.Common;
using FinanceAI.Core.Entities.AppUserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Entities.FixedCostEntity
{
    public class FixedCostCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;

        public ICollection<FixedCost> FixedCosts { get; set; }     = new List<FixedCost>(); // bir kategoriye ait bir çok sabit maliyet olabilir
    }
}
