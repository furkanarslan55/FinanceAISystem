using FinanceAI.Application.Features.AppUser;
using FinanceAI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceAI.Application.Features.User
{
    public class UserSettingService: IUserSettingService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int CurrentUserId;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserSettingService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }



        public async Task UpdateAsync(int userId, AppUserUpdateDto updateDto)
        {
            if (userId != CurrentUserId)
                throw new Exception("Kendi profilinizi güncelleyebilirsiniz.");

            var user = await _userRepository.GetByIdAsync(CurrentUserId);

            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            // 2. DTO'daki bilgileri Entity'ye aktar (Mapping)
            user.FirstName = updateDto.FirstName;
            user.LastName = updateDto.LastName;
            user.PhoneNumber = updateDto.PhoneNumber;

            // 3. Değişiklikleri kaydet
            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
