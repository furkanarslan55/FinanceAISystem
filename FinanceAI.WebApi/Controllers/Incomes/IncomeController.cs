using FinanceAI.Application.Features.Incomes;
using FinanceAI.Business.Features.Incomes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers.Incomes
{
    [Authorize] // Sadece giriş yapmış kullanıcılar erişebilir
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;


        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Servis katmanı zaten içerdeki kural gereği sadece bu kullanıcıya ait verileri getirecek
            var result = await _incomeService.GetAllByCurrentUserAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IncomeCreateDto dto)
        {
            await _incomeService.CreateAsync(dto);
            return StatusCode(201); // Created
        }
        [HttpDelete("delete-income/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _incomeService.Delete(id);
            return NoContent();


        }
        [HttpPut]
        public async Task<IActionResult> Update(IncomeUpdateDto dto)
        {
            await _incomeService.Update(dto);
            return NoContent();
        }

        [HttpGet("get-income-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _incomeService.GetByIdWithCategoryAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
