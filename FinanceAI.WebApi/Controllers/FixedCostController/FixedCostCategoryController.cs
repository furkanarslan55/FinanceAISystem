using FinanceAI.Application.Features.FixedCosts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers.FixedCostController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FixedCostCategoryController : ControllerBase
    {

        private readonly IFixedCostCategoryService _service;
        public FixedCostCategoryController(IFixedCostCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _service.GetAllByUserIdAsync(); //service içindeki CurrentUserId sayesinde otomatik olarak sadece o kullanıcının verileri gelir.
            return Ok(result);




        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _service.GetByWithId(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }




        [HttpPost]
        public async Task<IActionResult> Create(FixedCostCategoryCreateDto dto)
        {
            await _service.CreateAsync(dto); //UserId parametresi yok , servis onu token'dan hallediyor.
            return StatusCode(201);
        }
        [HttpPut]

        public async Task<IActionResult> Update(FixedCostCategoryUpdateDto dto)
        {
            await _service.UpdateAsync(dto); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
