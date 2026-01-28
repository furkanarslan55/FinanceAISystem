using FinanceAI.Application.Dtos.AppUser;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher,ITokenService tokenService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }
        // Constructor'a ITokenService enjekte etmeyi unutma!
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
            var hashedPassword = _passwordHasher.HashPassword(dto.Password);
            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = hashedPassword, 
                MonthlyIncome = dto.MonthlyIncome
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
    }
}
