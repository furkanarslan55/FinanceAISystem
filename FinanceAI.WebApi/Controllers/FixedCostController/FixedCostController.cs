using FinanceAI.Application.Features.FixedCosts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers.FixedCostController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FixedCostController : ControllerBase
    {

        private readonly IFixedCostService _fixedCostService;

        public FixedCostController(IFixedCostService fixedCostService)
        {
            _fixedCostService = fixedCostService;
        }


        [HttpGet("all-fixedcost")]
        public async Task<IActionResult> GetAll()
        {
            var fixedCosts = await _fixedCostService.GetAllWithCategoryAsync();
            return Ok(fixedCosts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fixedCost = await _fixedCostService.GetByIdWithCategoryAsync(id);
            if (fixedCost == null) { return NotFound(); }
            return Ok(fixedCost);
        }
        [HttpPost]
        public async Task<IActionResult> Create(FixedCostCreateDto dto)
        {
            await _fixedCostService.CreateAsync(dto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, FixedCostUpdateDto dto)
        {
            await _fixedCostService.UpdateAsync(id, dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fixedCostService.DeleteAsync(id);
            return Ok();





        }
    }
}
