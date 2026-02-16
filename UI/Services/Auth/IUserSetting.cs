using UI.Models.Auth;

namespace UI.Services.Auth
{
    public interface IUserSetting
    {
        Task<UserViewDto> GetCurrentUserAsync(int id);
        Task UpdateAsync ( UserUpdateDto userUpdateDto);
    }
}
