using FinanceAI.Application.Dtos.Transaction;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Interfaces;

namespace FinanceAI.Application.Services
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IDebtRepository _debtRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository transactionRepository, IDebtRepository debtRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService) :base(currentUserService)
        {
            _transactionRepository = transactionRepository;
            _debtRepository = debtRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateTransactionAsync(TransactionCreateDto dto)
        {
            var transaction = new Transaction
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Type = (TransactionType)dto.TransactionType,
                Category = dto.Category,
                AppUserId = CurrentUserId,
            };

            await _transactionRepository.AddAsync(transaction);

            // İŞ KURALI: Eğer kategori "Borç Ödemesi" ise ilgili borcu bul ve düş
            if (dto.DebtId.HasValue)
            {
                var debt = await _debtRepository.GetByIdAsync(dto.DebtId.Value);

                if (debt != null && debt.AppUserId == CurrentUserId)
                {
                    // Borçtan ödenen miktarı düş
                    debt.RemainingAmount -= dto.Amount;

                    // Eğer borç tamamen bittiyse (veya eksiye düştüyse) 0'a sabitle
                    if (debt.RemainingAmount < 0) debt.RemainingAmount = 0;

                    _debtRepository.Update(debt);
                }
            }

            // 3. UnitOfWork ile iki işlemi birden veritabanına onayla (Atomicity)
            await _unitOfWork.CommitAsync();
        }
    }
}
