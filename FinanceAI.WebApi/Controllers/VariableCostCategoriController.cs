using FinanceAI.Application.Features.VariableCosts.VariableCostCategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VariableCostCategoriController : ControllerBase
    {
        private readonly IVariableCostCategoryService _variableCostCategoryService;

        public VariableCostCategoriController(IVariableCostCategoryService variableCostCategoryService)
        {
            _variableCostCategoryService = variableCostCategoryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(VariableCategoryCreateDto dto)
        {
            await _variableCostCategoryService.CreateCategory(dto);
            return Ok();
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _variableCostCategoryService.DeleteCategory(categoryId);
            return Ok();
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory(VariableCategoryUpdateDto dto)
        {
            await _variableCostCategoryService.UpdateCategory(dto);
            return Ok();


        }
    }
}