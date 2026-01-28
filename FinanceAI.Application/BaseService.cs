using FinanceAI.Application.Interfaces;

namespace FinanceAI.Application
{
    public abstract class BaseService
    {
        private readonly ICurrentUserService _currentUserService;

        protected BaseService(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        // Alt sınıflar her seferinde _currentUserService.UserId yazmasın diye 
        // bir kısa yol (property) ekliyoruz.
        protected int CurrentUserId => _currentUserService.UserId;
    }
}
