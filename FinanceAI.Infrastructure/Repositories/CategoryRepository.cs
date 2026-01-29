using FinanceAI.Application.Dtos.Category;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Interfaces;
using FinanceAI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace FinanceAI.Infrastructure.Repositories
{

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context) { _context = context; }

        public async Task<List<Category>> GetCategoriesByFilterAsync(CategoryType type, int? userId)
        {
            // EF Core burada çalışır. 
            // SQL'e gidip "Bana şu tipteki ve şu kullanıcıya ait kategorileri getir" der.
            return await _context.Categories
                .AsNoTracking()
                .Where(x => x.Type == type && (x.AppUserId == null || x.AppUserId == userId))
                .ToListAsync();
        }
    }
}

