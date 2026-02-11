using FinanceAI.Application.Features.Debts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers.Debts
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DebtController : ControllerBase
    {
        private readonly IDebtServices _debtServices;

         public DebtController(IDebtServices debtServices)
        {

            _debtServices = debtServices;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var debts = await _debtServices.GetAllByUserIdAsync();
            return Ok(debts);
        }


        [HttpPost("create-debt")]
        public async Task<IActionResult> CreateDebt (DebtCreateDto dto)
        {
            await _debtServices.CreateAsync(dto);
            return Ok();

         


        }
        [HttpGet("get-debt-category/{id}")]
        public async Task<IActionResult> GetDebtWithCategoryById(int id)
        {
            var debt = await _debtServices.GetDebtWithCategoryByIdAsync(id);
            if (debt == null) { return NotFound(); }
            return Ok(debt);
        }




        [HttpPut("update-debt")]
        public async Task<IActionResult> Update(DebtUpdateDto dto)
        {
          await _debtServices.UpdateAsync(dto);
            return Ok();


        }
        [HttpDelete("delete-debt/{id}")]
        public  async Task<IActionResult> Delete(int id)
        {
             await _debtServices.DeleteAsync(id);
            return NoContent();
        }




    }
}
