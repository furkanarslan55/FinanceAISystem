using FinanceAI.Application.Features.Incomes;
using FinanceAI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers.Incomes
{
    [Authorize] // Kullanıcının giriş yapmış (token sahibi) olması zorunlu
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeCategoriesController : ControllerBase
    {
        private readonly IIncomeCategoryService _service;

        public IncomeCategoriesController(IIncomeCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Servis içindeki CurrentUserId sayesinde otomatik olarak sadece o kullanıcının verileri gelir.
            var result = await _service.GetAllByUserIdAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IncomeCategoryCreateDto dto)
        {
            // UserId parametresi kalktı, servis bunu token'dan hallediyor.
            await _service.CreateAsync(dto);
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> Update(IncomeCategoryUpdateDto dto)
        {
            // Global Exception Handler sayesinde try-catch'e gerek yok.
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

