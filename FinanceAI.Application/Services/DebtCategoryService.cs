using FinanceAI.Application.Dtos.Debt;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Services
{
    public class DebtCategoryService : IDebtCategoryService
    {
        private readonly IGenericRepository<DebtCategory> _categoryRepository;

        public DebtCategoryService(IGenericRepository<DebtCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<DebtCategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.Select(x => new DebtCategoryDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
