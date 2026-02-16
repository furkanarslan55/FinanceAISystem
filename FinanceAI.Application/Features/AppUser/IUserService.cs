using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.AppUser
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<TokenResponseDto> LoginAsync(UserLoginDto loginDto);

        Task<UserViewDto> GetUserProfileById (int id);
    }
}
