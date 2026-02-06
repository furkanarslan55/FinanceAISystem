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
    }
}
