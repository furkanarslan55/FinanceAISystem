using UI.Models;
using UI.Models.Auth;

namespace UI.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            // Program.cs'de tanımladığımız "AuthClient" (BaseAddress'i olan istemci)
            _httpClient = httpClientFactory.CreateClient("AuthClient");
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> LoginAsync(UserLoginDto loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();

                // Token'ı Cookie içine gömüyoruz
                _httpContextAccessor.HttpContext.Response.Cookies.Append("JwtToken", result.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddMinutes(60)
                });
                return true;
            }
            return false;
        }

        public async Task<string> GetTokenAsync()
        {
            return _httpContextAccessor.HttpContext.Request.Cookies["JwtToken"];
        }

        public async Task LogoutAsync()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("JwtToken");
        }

        public async Task<UserDto> RegisterAsync(UserRegisterDto registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users/register", registerModel);

            if (!response.IsSuccessStatusCode)
            {
                
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Register failed: {error}");
            }

            var createdUser = await response.Content.ReadFromJsonAsync<UserDto>();

            return createdUser;

        }
    }
}
