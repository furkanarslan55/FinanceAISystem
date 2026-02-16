using FinanceAI.Application.Features.AppUser;
using FinanceAI.Application.Features.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {

        private readonly IUserSettingService _userService;

        public UserProfileController(IUserSettingService userService)
        {
            _userService = userService;
        }


        [HttpPut("profile/{id}")]
        public async Task<IActionResult> UpdateProfile(int id, AppUserUpdateDto updateDto)
        {
            await _userService.UpdateAsync(id, updateDto);


            return Ok(new { message = "Profil başarıyla güncellendi." });

        }
    }
}
