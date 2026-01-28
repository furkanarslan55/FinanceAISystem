using FinanceAI.Application.Dtos.Debt;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Interfaces;

namespace FinanceAI.Application.Services
{
    public class DebtService : BaseService ,IDebtService
    {
        private readonly IDebtRepository _debtRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        public DebtService(IDebtRepository debtRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService) : base(currentUserService)
        {
            _debtRepository = debtRepository;
            _unitOfWork = unitOfWork;
           
        }

        public async Task<int> CreateDebtAsync(DebtCreateDto dto)
        {
            // Basit bir iş kuralı (Business Rule)
            if (dto.RemainingAmount > dto.TotalAmount)
                throw new Exception("Kalan borç, toplam borçtan büyük olamaz!");

            var debt = new Debt
            {
                Title = dto.Title,
                TotalAmount = dto.TotalAmount,
                RemainingAmount = dto.RemainingAmount,
                InterestRate = dto.InterestRate,
                DueDate = dto.DueDate,
                Priority = dto.Priority,
                AppUserId = CurrentUserId,
                DebtCategoryId = dto.DebtCategoryId
            };

            await _debtRepository.AddAsync(debt);
            await _unitOfWork.CommitAsync();

            return debt.Id;
        }

        public async Task<List<DebtDto>> GetDebtsByUserIdAsync(int userId)
        {
            var debts = await _debtRepository.GetDebtsByUserIdWithDetailsAsync(userId);

            return debts.Select(x => new DebtDto
            {
                Id = x.Id,
                Title = x.Title,
                RemainingAmount = x.RemainingAmount,
                DueDate = x.DueDate,
                CategoryName = x.DebtCategory.Name
            }).ToList();
        }
    }
}

