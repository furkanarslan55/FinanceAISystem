using FinanceAI.Application.Features.AppUser;
using FinanceAI.Application.Features.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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


        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] AppUserUpdateDto updateDto)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized();

            if (!int.TryParse(userIdClaim, out var userId))
                return Unauthorized();

            await _userService.UpdateAsync(userId, updateDto);

            return Ok(new { message = "Profil başarıyla güncellendi." });
        }
    }
}
