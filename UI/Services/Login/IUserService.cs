using UI.Models.ViewModel;

namespace UI.Services.Login
{
    public interface IUserService
    {
        Task<string?> LoginAsync(LoginViewModel model);
    }
}
