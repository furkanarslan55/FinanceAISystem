using Microsoft.AspNetCore.Mvc;
using UI.Services.AI;

namespace UI.Controllers
{
    public class AiController : Controller
    {
        private readonly IAiService _aiService;

        public AiController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ask(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                ModelState.AddModelError("", "Prompt boş olamaz");
                return View("Index");
            }

            try
            {
                var result = await _aiService.GenerateAsync(prompt);
                ViewBag.Result = result;
                return View("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "AI hatası: " + ex.Message);
                return View("Index");
            }
        }
    }
}
