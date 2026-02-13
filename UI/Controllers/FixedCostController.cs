using Microsoft.AspNetCore.Mvc;
using UI.Models.FixedCost;
using UI.Services.FixedCost;

namespace UI.Controllers
{
    public class FixedCostController : Controller
    {
        private readonly IFixedCostService _fixedCostService;
        private readonly IFixedCostCategoryService _fixedCostCategoryService;

        public FixedCostController(IFixedCostService fixedCostService, IFixedCostCategoryService fixedCostCategoryService)
        {
            _fixedCostService = fixedCostService;
            _fixedCostCategoryService = fixedCostCategoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fixedCosts = await _fixedCostService.GetAllWithCategoryAsync();
            return View(fixedCosts);


        }

        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            
            var categories = await _fixedCostCategoryService.GetAllByUserIdAsync();

            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FixedCostCreateDto dto)
        {
            
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _fixedCostCategoryService.GetAllByUserIdAsync();
                return View(dto);
            }


            try
            {
                await _fixedCostService.CreateAsync(dto);
                TempData["SuccessMessage"] = " Başarıyla eklendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu: " + ex.Message);


                ViewBag.Categories = await _fixedCostCategoryService.GetAllByUserIdAsync();

                return View(dto);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _fixedCostService.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // Silme başarısızsa hata yönetimi
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var fixedCost = await _fixedCostService.GetByIdWithCategoryAsync(id);
            if (fixedCost == null)
            {
                return NotFound();
            }
            var categories = await _fixedCostCategoryService.GetAllByUserIdAsync();
            ViewBag.Categories = categories;

            return View(fixedCost);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FixedCostUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _fixedCostCategoryService.GetAllByUserIdAsync();
                return View("Update", dto);
            }
            try
            {
                await _fixedCostService.UpdateAsync(id,dto);
                TempData["SuccessMessage"] = "Gider başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                ViewBag.Categories = await _fixedCostCategoryService.GetAllByUserIdAsync();
                return View("UpdateForm", dto);
            }
        }





    }
}
