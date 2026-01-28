using FinanceAI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceAI.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // İstekteki Token'ı çözer ve içindeki UserId'yi alır
        public int UserId => int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
    }
}
