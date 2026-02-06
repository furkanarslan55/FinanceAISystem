using Microsoft.AspNetCore.Mvc;
using UI.Models.Incomes;
using UI.Services.Incomes;

namespace UI.Controllers
{
    // Sadece giriş yapmış kullanıcılar erişebilsin
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IIncomeCategoryService _categoryService;

        public IncomeController(IIncomeService incomeService, IIncomeCategoryService categoryService)
        {
            _incomeService = incomeService;
            _categoryService = categoryService; // Gelir eklerken kategori seçtirmek için ihtiyacımız olacak
        }

        // 1. Tüm Gelirleri Listeleme (Index)
        public async Task<IActionResult> Index()
        {
            // Servis üzerinden giriş yapmış kullanıcının gelirlerini çekiyoruz
            var incomes = await _incomeService.GetAllByCurrentUserAsync();
            return View(incomes);
        }

        // 2. Yeni Gelir Ekleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // Gelir eklerken bir kategori seçilmesi gerekir (Maaş, Kira vb.)
            // Bu yüzden kategori listesini çekip ViewBag veya bir ViewModel ile sayfaya gönderiyoruz
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;

            return View();
        }

        // 3. Yeni Gelir Ekleme İşlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncomeCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                // Model geçersizse kategorileri tekrar yükle ve sayfayı hatalarla dön
                ViewBag.Categories = await _categoryService.GetAllAsync();
                return View(dto);
            }

            try
            {
                await _incomeService.CreateAsync(dto);
                TempData["SuccessMessage"] = "Gelir başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Gelir kaydedilirken bir hata oluştu. Lütfen tekrar deneyin.");
                ViewBag.Categories = await _categoryService.GetAllAsync();
                return View(dto);
            }
        }
    }
}