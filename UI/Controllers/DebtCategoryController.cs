using Microsoft.AspNetCore.Mvc;
using UI.Models.Debt;
using UI.Services.Debt;

namespace UI.Controllers
{
    public class DebtCategoryController : Controller
    {
        private readonly IDebtCategoryService _debtCategoryService;

        public DebtCategoryController(IDebtCategoryService debtCategoryService)
        {
            _debtCategoryService = debtCategoryService;
        }

        // Listeleme (Index)
        public async Task<IActionResult> Index()
        {
            var categories = await _debtCategoryService.GetAllByUserIdAsync();
            return View(categories);
        }

        // Yeni Kategori Ekleme (Get)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Kategori Ekleme (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DebtCategoryCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _debtCategoryService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme (Get)
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var categories = await _debtCategoryService.GetAllByUserIdAsync();
            var category = categories.FirstOrDefault(x => x.Id == id);

            if (category == null) return NotFound();

            var updateDto = new DebtCategoryUpdateDto
            {
                Id = category.Id,
                Name = category.Name
                // DTO'daki diğer alanları buraya eşleyebilirsin
            };

            return View(updateDto);
        }

        // Güncelleme (Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(DebtCategoryUpdateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _debtCategoryService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _debtCategoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}