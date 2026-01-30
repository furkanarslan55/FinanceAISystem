using AutoMapper;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Interfaces;

namespace FinanceAI.Application.Features.Debts
{
    public class DebtServices :BaseService, IDebtServices
    {
        private readonly IDebtRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DebtServices(
            ICurrentUserService currentUserService) : base(currentUserService)
        {



        }

        public Task CreateAsync(DebtCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DebtDto>> GetAllByUserIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DebtUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
