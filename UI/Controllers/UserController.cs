using Microsoft.AspNetCore.Mvc;
using UI.Services.Auth;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserSetting _userSetting;
        public UserController(IUserSetting userSetting)
        {
            _userSetting = userSetting;
        }
        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var userProfile = await _userSetting.GetCurrentUserAsync(id);
            if (userProfile == null)
            {
                return RedirectToAction("Login");
            }
            return View(userProfile);
        }
    }
}
