using FinanceAI.Application.AIConfigurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiController : ControllerBase
    {
        private readonly IAIService _aiService;

        public AiController(IAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] string prompt)
        {
            var result = await _aiService.GenerateAsync(prompt);
            return Ok(result);
        }
    }
}
