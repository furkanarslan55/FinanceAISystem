using FinanceAI.Application;
using FinanceAI.Application.Dtos.Category;
using FinanceAI.Application.Dtos.Debt;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Interfaces;

namespace FinanceAI.Application.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService) : base(currentUserService)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryDto>> GetCategoriesByTypeAsync(CategoryType type)
        {
            // 1. Repository'den HAM VERİYİ (Entity) istiyoruz. 
            // Repository içindeki filtreleme senin "Anayasanı" uyguluyor (null veya CurrentUserId)
            var rawCategories = await _categoryRepository.GetCategoriesByFilterAsync(type, CurrentUserId);

            // 2. MAPPING: Ham veriyi DTO'ya çeviriyoruz (Düz C# ile)
            return rawCategories.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                CategoryType = (int)x.Type,
                IsCustom = x.AppUserId.HasValue // AppUserId varsa kullanıcı oluşturmuştur
            }).ToList();
        }

        public async Task CreateCustomCategoryAsync(CategoryCreateDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Type = (CategoryType)dto.CategoryType,
                AppUserId = CurrentUserId // Senin kuralın: Giriş yapanın ID'si
            };

            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCustomCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            // GÜVENLİK: Eğer kategori sistem kategorisiyse (null) veya başkasınaysa silemez!
            if (category != null && category.AppUserId == CurrentUserId)
            {
                _categoryRepository.Remove(category);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}