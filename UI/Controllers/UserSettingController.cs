using Microsoft.AspNetCore.Mvc;
using UI.Models.Auth;
using UI.Services.Auth;

namespace UI.Controllers
{
    public class UserSettingController : Controller
    {
        private readonly IUserSetting _userSetting;
        public UserSettingController(IUserSetting userSetting)
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

        [HttpGet]
        public async Task<IActionResult> UpdateForm(int id)
        {
            UserViewDto currentprofile = await _userSetting.GetCurrentUserAsync(id);
            if (currentprofile == null) return NotFound();
            var updateDto = new UserUpdateDto
            (
               currentprofile.FirstName,
               currentprofile.LastName,
              currentprofile.PhoneNumber

            );

            ViewData["TargetId"] = currentprofile.Id;
            return View(updateDto);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile( UserUpdateDto profileModel)
        {

            if (!ModelState.IsValid)
            {
                return View("UpdateForm", profileModel); // Hata varsa formu verilerle geri dön
            }

            try
            {
                // Senin yazdığın Service metodunu çağırıyoruz
                await _userSetting.UpdateAsync( profileModel);

                // Başarılıysa Profile sayfasına veya Ana sayfaya yönlendir
                TempData["SuccessMessage"] = "Profiliniz başarıyla güncellendi.";
                return RedirectToAction("Profile", "UserSetting");
            }
            catch (Exception ex)
            {
                // Servis katmanında fırlattığın Exception'ı burada yakalayıp ekrana mesaj basıyoruz
                ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu: " + ex.Message);
                return View("UpdateForm", profileModel);
            }


        }
    }
}
