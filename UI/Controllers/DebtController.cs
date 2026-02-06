using Microsoft.AspNetCore.Mvc;
using UI.Models.Debt;
using UI.Services.Debt;

namespace UI.Controllers
{
    public class DebtController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IDebtCategoryService _debtCategoryService;


        public DebtController(IDebtService debtService,IDebtCategoryService debtCategoryService)
        {
            _debtService = debtService;
            _debtCategoryService = debtCategoryService;
        }

       
        public async Task<IActionResult> Index()
        {
            var debts = await _debtService.DebtAllWithCategories();

            return View(debts);
        }

        // Yeni Borç Ekleme Sayfası (Form)
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _debtCategoryService.GetAllByUserIdAsync();
            ViewBag.Categories = categories;

            return View();
        }

        // Yeni Borç Ekleme İşlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DebtCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _debtCategoryService.GetAllByUserIdAsync();
                return View(dto);
            }

            try
            {
                await _debtService.CreateDebt(dto);
                TempData["SuccessMessage"] = "Borç başarıyla eklendi."; // "Gelir" yazmışsın, "Borç" olarak düzeltebilirsin :)
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu: " + ex.Message);

                // BURASI DÜZELTİLDİ: Borç servisi değil, Kategori servisi çağrılmalı
                ViewBag.Categories = await _debtCategoryService.GetAllByUserIdAsync();

                return View(dto);
            }
        }

        // Borç Silme İşlemi
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _debtService.DeleteDebt(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // Silme başarısızsa hata yönetimi
                return RedirectToAction(nameof(Index));
            }
        }
    }
}