using FinanceAI.Application.Dtos.Debt;
using FinanceAI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DebtsController : ControllerBase
    {
        private readonly IDebtService _debtService;

        public DebtsController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DebtCreateDto debtCreateDto)
        {
            var result = await _debtService.CreateDebtAsync(debtCreateDto);
            return Ok(new { message = "Borç başarıyla eklendi", id = result });
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserDebts(int userId)
        {
            var result = await _debtService.GetDebtsByUserIdAsync(userId);
            return Ok(result);
        }
    }
}
