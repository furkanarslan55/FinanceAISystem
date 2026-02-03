using FinanceAI.Application.Features.Debts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers.Debts
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DebtCategoryController : ControllerBase
    {
        private readonly IDebtCategoryServices _debtCategoryServices;

        public DebtCategoryController(IDebtCategoryServices debtCategoryServices)
        {
            _debtCategoryServices = debtCategoryServices;
        }




        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(DebtCategoryCreateDto dto)
        {
            await _debtCategoryServices.CreateAsync(dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _debtCategoryServices.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(DebtCategoryUpdateDto dto)
        {
            await _debtCategoryServices.UpdateAsync(dto);
            return Ok();




        }
    }
}
