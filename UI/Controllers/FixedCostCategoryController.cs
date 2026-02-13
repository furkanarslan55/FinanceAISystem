using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Models.Debt;
using UI.Models.FixedCost.FixedCostCategory;
using UI.Services.FixedCost;

namespace UI.Controllers
{
    public class FixedCostCategoryController : Controller
    {
        private readonly IFixedCostCategoryService _service;
        public FixedCostCategoryController(IFixedCostCategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var list = await _service.GetAllByUserIdAsync();


            return View(list);
        }
            [HttpGet]

            public async Task<IActionResult> Create()
            {
                return View();
            }

        [HttpPost]
        public async Task<IActionResult> Create(FixedCostCategoryCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
