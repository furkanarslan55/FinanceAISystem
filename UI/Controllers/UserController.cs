using Microsoft.AspNetCore.Mvc;
using UI.Models.ViewModel;
using UI.Services.Login;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _authService;

        public UserController(IUserService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Eğer kullanıcı zaten giriş yapmışsa tekrar login sayfasını görmesin
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("JWT")))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var token = await _authService.LoginAsync(model);

            if (string.IsNullOrEmpty(token)) // null veya boş gelme kontrolü
            {
                ViewBag.Error = "Email veya şifre hatalı";
                return View(model);
            }

            // JWT'yi SESSION içinde sakla
            HttpContext.Session.SetString("JWT", token);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // Session'ı tamamen temizlemek sadece JWT'yi silmekten daha güvenlidir
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}