using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using UI.Services.Dashboard;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDashboard _apiService;

        public HomeController(IDashboard apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _apiService.GetDashboardSummaryAsync();
            return View(model);
        }

      

    }
}
