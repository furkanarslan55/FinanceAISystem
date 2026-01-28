using FinanceAI.Application.Dtos.AppUser;
using FinanceAI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            // Kullanıcıyı kaydet ve sonucunu DTO olarak dön
            var result = await _userService.RegisterAsync(userRegisterDto);

            // 201 Created yanıtı dönerken yeni oluşturulan kaynağın bilgisini veririz
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var result = await _userService.LoginAsync(loginDto);
            return Ok(result);
        }
    }
}
