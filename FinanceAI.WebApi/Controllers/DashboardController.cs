using FinanceAI.Application.Features.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("rates")] 
        public async Task<IActionResult> GetCurrencyRates()
        {
            
            var result = await _dashboardService.GetDashboardRatesAsync();

            // 2. Eğer mutfakta bir sorun olduysa ve veri gelmediyse
            if (result == null || !result.Any())
            {
                return NotFound("Şu an döviz bilgilerine ulaşılamıyor.");
            }

            
            return Ok(result);
        }
    }
}

