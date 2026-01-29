using FinanceAI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinanceAI.Core.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // Projection işlemini Service katmanında Handle edeceğiz ya da 
        // DTO'yu Core'a taşıyacağız. Şimdilik hatayı çözmek için:
        Task<List<Category>> GetCategoriesByFilterAsync(CategoryType type, int? userId);
    }
}

