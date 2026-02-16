using FinanceAI.Application.Features.Dashboard;
using FinanceAI.Application.Features.Debts;
using FinanceAI.Application.Features.FixedCosts;
using FinanceAI.Application.Features.Incomes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenericController : ControllerBase
    {

        private readonly IDebtServices _debtService;
        private readonly IIncomeService _incomeService;
        private readonly IFixedCostService _fixedCostService;
        public GenericController( IDebtServices debtService ,IIncomeService ıncomeService,IFixedCostService fixedCostService)
        {
          
            _debtService = debtService;
            _incomeService = ıncomeService;
            _fixedCostService = fixedCostService;

        }
        [HttpGet("dashboard")]
        public async Task<IActionResult> Index()
        {
            // Paralel olarak verileri çekiyoruz (Performans için)
         
            var debtTask = await _debtService.GetLastDebtAsync();
            var debtIncomeTask = await _incomeService.GetLastIncomeAsync();
            var fixedCostTask = await _fixedCostService.GetLastFixedCostAsync();


            var viewModel = new DashboardViewModel
            {
                
                LastDebt = debtTask,
                LastIncome = debtIncomeTask,
                LastFixedCost = fixedCostTask


            };

            return Ok(viewModel);
        }



    }

}
