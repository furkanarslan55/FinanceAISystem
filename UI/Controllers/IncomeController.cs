using Microsoft.AspNetCore.Mvc;
using UI.Models.ViewModel.Income;
using UI.Services;
using UI.Services.Income;

namespace UI.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        public async Task<IActionResult> Index()
        {
            var incomes = await _incomeService.GetAllAsync();
            return View(incomes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IncomeCreateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _incomeService.CreateAsync(dto);
            return RedirectToAction("Index");
        }
    }

}
