using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceAI.Application.Features.AppUser
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int CurrentUserId;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher,ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
            // Giriş yapan kullanıcının ID'sini Claims üzerinden güvenli bir şekilde alıyoruz
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }
       
        public async Task<TokenResponseDto> LoginAsync(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user == null || !_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                throw new Exception("Email veya şifre hatalı!");
            }

            // Bilgiler doğru, token üret
            return _tokenService.CreateToken(user);
        }




        public async Task<UserDto> RegisterAsync(UserRegisterDto dto)
        {
            var emailExists = await _userRepository.EmailExistsAsync(dto.Email);
            throw new Exception(emailExists ? "Bu email zaten kayıtlı!" : "Kayıt işlemi sırasında bir hata oluştu!");

            var hashedPassword = _passwordHasher.HashPassword(dto.Password);
            var user = new Core.Entities.AppUserEntity.AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = hashedPassword, 
                MonthlyIncome = dto.MonthlyIncome,
                PhoneNumber = dto.PhoneNumber
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return new UserDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                MonthlyIncome = user.MonthlyIncome
            };
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("Kullanıcı bulunamadı");

            return new UserDto { Id = user.Id, FullName = $"{user.FirstName} {user.LastName}", Email = user.Email, MonthlyIncome = user.MonthlyIncome };
        }

        public async Task<UserViewDto> GetUserProfileById(int id)
        {
            var user = await _userRepository.GetByIdAsync(CurrentUserId);
            if (user == null) throw new Exception("Kullanıcı bulunamadı");
          return new UserViewDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                MonthlyIncome = user.MonthlyIncome
            };
        }
        

    }
}
