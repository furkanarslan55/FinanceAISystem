using FinanceAI.Application.Features.AppUser;

namespace FinanceAI.Application.Features.User
{
    public interface IUserSettingService
    {
        Task UpdateAsync (int userId, AppUserUpdateDto updateDto);
    }
}
