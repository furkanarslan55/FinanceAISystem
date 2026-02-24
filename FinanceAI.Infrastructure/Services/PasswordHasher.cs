using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities.AppUserEntity;
using Microsoft.AspNetCore.Identity;

namespace FinanceAI.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<AppUser> _hasher = new();

        public string HashPassword(string password) => _hasher.HashPassword(null!, password);

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null!, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
