using Microsoft.AspNetCore.Mvc;
using UI.Models.Auth;
using UI.Services.Auth;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserSetting _userSetting;

        public AccountController(IAuthService authService )
        {
            _authService = authService;
         
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Sadece giriş sayfasını gösterir
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            // AuthService üzerinden API'ye gidiyoruz
            var result = await _authService.LoginAsync(loginModel);

            if (result)
            {
                // Giriş başarılıysa ana sayfaya gönder
                return RedirectToAction("Index", "Home");
            }

            // Giriş başarısızsa hata mesajı ekle
            ModelState.AddModelError("", "E-posta veya şifre hatalı.");
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            var result = await _authService.RegisterAsync(registerModel);
            if (result != null)
            {
                // Kayıt başarılıysa giriş sayfasına yönlendir
                return RedirectToAction("Login");
            }
            // Kayıt başarısızsa hata mesajı ekle
            ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu.");
            return View(registerModel);
        }
       
    }
}
