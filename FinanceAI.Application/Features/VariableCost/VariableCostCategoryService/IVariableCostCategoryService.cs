using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.VariableCosts.VariableCostCategoryService
{
    public interface IVariableCostCategoryService 
    {

        Task<IEnumerable<string>> GetAllCategoriesAsync();

        Task CreateCategory(VariableCategoryCreateDto dto);

        Task UpdateCategory(VariableCategoryUpdateDto dto);

        Task DeleteCategory(int categoryId);



    }
}
