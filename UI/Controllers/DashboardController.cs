using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Exchange()
        {
            return View();
        }
    }
}
