using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Common
{
    public abstract class BaseEntity // abstract class kullanmamın sebebi ortak özellikler olup audit fields eklemek istemem ve bu sınıfın direkt olarak örneklenmesini engellemek
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    
    }
}
