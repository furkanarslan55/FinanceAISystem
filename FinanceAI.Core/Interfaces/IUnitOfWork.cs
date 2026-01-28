using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync(); // SaveChangesAsync() yerine bunu çağıracağız
        void Commit();
    }
}
