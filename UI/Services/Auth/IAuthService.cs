using UI.Models.Auth;

namespace UI.Services.Auth
{
    public interface IAuthService
    {
        // Kullanıcı giriş yapar ve başarılıysa true döner
        Task<bool> LoginAsync(UserLoginDto loginModel);

        // Mevcut token'ı döner
        Task<string> GetTokenAsync();

        // Çıkış işlemi ve token temizliği
        Task LogoutAsync();


        Task<UserDto> RegisterAsync(UserRegisterDto registerModel);

 
    }
}
