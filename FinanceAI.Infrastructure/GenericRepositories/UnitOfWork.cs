using FinanceAI.Core.Interfaces;
using FinanceAI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) => _context = context;

        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public void Commit() => _context.SaveChanges();
    }
}
