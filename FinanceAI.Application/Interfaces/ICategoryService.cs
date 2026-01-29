using FinanceAI.Application.Dtos.Category;
using FinanceAI.Application.Dtos.Debt;
using FinanceAI.Core.Entities;

namespace FinanceAI.Application.Interfaces
{
    public interface ICategoryService
    {
        // Türüne göre (Borç, Gelir vb.) kategorileri listeler
        Task<List<CategoryDto>> GetCategoriesByTypeAsync(CategoryType type);

        // Kullanıcıya özel yeni kategori ekler
        Task CreateCustomCategoryAsync(CategoryCreateDto dto);

        // Kullanıcının kendi eklediği kategoriyi siler
        Task DeleteCustomCategoryAsync(int id);
    }
}