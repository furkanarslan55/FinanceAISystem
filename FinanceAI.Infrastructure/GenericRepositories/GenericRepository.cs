using FinanceAI.Core.Common;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Interfaces;
using FinanceAI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            // EF Core bağımlılığı burada (Infrastructure katmanında) kalıyor
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public void Remove(T entity) => _dbSet.Remove(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => _dbSet.Where(expression);
        public async Task<T?> GetLastRecordAsync(Expression<Func<T, object>> orderByExpression, bool isDescending = true)
        {
            var query = _dbSet.AsQueryable();

            if (isDescending)
                return await query.OrderByDescending(orderByExpression).FirstOrDefaultAsync();

            return await query.OrderBy(orderByExpression).FirstOrDefaultAsync();
        }

    }
}
