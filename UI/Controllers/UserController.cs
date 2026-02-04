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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var token = await _authService.LoginAsync(model);

            if (token == null)
            {
                ViewBag.Error = "Email veya şifre hatalı";
                return View();
            }

            // JWT'yi COOKIE içinde sakla (EN DOĞRU YÖNTEM)
            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Login");
        }
    }

}
