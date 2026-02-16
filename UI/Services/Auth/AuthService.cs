using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

                // 1. Token'ı çözmek için handler oluştur
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(result.Token);

                // 2. Token içindeki Claim'leri al
                var claims = jwtToken.Claims.ToList();

                // 3. Identity oluştur (AuthenticationType olarak "Jwt" veriyoruz)
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 4. Sisteme giriş yap (Bu adım User.Identity'yi doldurur)
                await _httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties { IsPersistent = true });

                // Opsiyonel: Token'ı yine de cookie'de saklayabilirsin
                _httpContextAccessor.HttpContext.Response.Cookies.Append("JwtToken", result.Token, new CookieOptions
                {
                    HttpOnly = true,
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
