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
        private readonly IGenericRepository<AppUser> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IGenericRepository<AppUser> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> RegisterAsync(UserRegisterDto dto)
        {
            // Gerçek projede şifre burada hash'lenmeli! Şimdilik basit tutuyoruz.
            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = dto.Password, // Şimdilik plain text, sonra düzelteceğiz
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
