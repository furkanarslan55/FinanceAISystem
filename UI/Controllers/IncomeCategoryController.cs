using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Incomes;
using UI.Services.Incomes;

namespace UI.Controllers
{
    //[Authorize]
    public class IncomeCategoryController : Controller
    {
        private readonly IIncomeCategoryService _categoryService;

        public IncomeCategoryController(IIncomeCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Listeleme Sayfası
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        // Yeni Kategori Ekleme (Sayfayı Göster)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni Kategori Ekleme (Formu Gönder)
        [HttpPost]
        public async Task<IActionResult> Create(IncomeCategoryCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _categoryService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
