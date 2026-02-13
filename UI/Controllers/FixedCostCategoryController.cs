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
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction(nameof(Index));
            }

        }


        [HttpGet]
        public async Task<IActionResult> UpdateForm(int id)
        {
            var category = await _service.GetByWithId(id);
            if (category == null) return NotFound();
           
            return View(category);
        }
        [HttpPost]

        public async Task<IActionResult> Update(FixedCostCategoryUpdateDto dto)
        {
            if (!ModelState.IsValid) return View("UpdateForm", dto);
            try
            {
                await _service.UpdateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("UpdateForm", dto);
            }
        }
        }
}
