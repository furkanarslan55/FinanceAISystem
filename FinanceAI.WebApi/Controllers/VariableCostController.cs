using FinanceAI.Application.Features.VariableCost.VariableCostService;
using FinanceAI.Application.Features.VariableCosts.VariableCostServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VariableCostController : ControllerBase
    {

        private readonly IVariableCostService _variableCostService;

        public VariableCostController(IVariableCostService variableCostService)
        {
            _variableCostService = variableCostService;
        }


        [HttpPost("Creat-variable-cost")]

        public async Task<IActionResult> CreateVariableCost(CreatVariableCostDto dto)
        {
            var result = _variableCostService.CreateVariableCost(dto);
            return Ok();


        }

        [HttpGet("Get-all-variable-cost")]
        public async Task<IActionResult> GetAllVariableCost()
        {
            var result = await _variableCostService.GetAllByIdVariableCost();
            return Ok(result);
        }

        [HttpPut("Update-variable-cost")]

        public async Task<IActionResult> UpdateVariableCost(UpdateVariableCostDto dto)
        {
            var result =  _variableCostService.UpdateVariableCost(dto);
            return Ok();
        }

        [HttpDelete("Delete-variable-cost/{id}")]
        public async Task<IActionResult> DeleteVariableCost(int id)
        {
            var result =  _variableCostService.DeleteVariableCost(id);
            return NoContent();
        }
    }
}
