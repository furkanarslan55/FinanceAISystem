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
            ICurrentUserService currentUserService,IDebtRepository debtRepository,IUnitOfWork unitOfWork,IMapper mapper) : base(currentUserService)
        {
            _repository = debtRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;


        }

        public async Task CreateAsync(DebtCreateDto dto)
        {
            var entity = _mapper.Map<Debt>(dto);
            entity.AppUserId = CurrentUserId;
           await  _repository.AddAsync(entity);
              await _unitOfWork.CommitAsync();
        }

        public  async Task DeleteAsync(int id)
        {
            var entity =await  _repository.GetByIdAsync(id);
            if (entity == null || entity.AppUserId != CurrentUserId)
                throw new Exception("Borç bulunamadı veya bu işlem için yetkiniz yok.");
            _repository.Remove(entity); //silme işlemleri asenkron olmayabilir
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<DebtDto>> GetAllByUserIdAsync()
        {
            
            var entities = await _repository.GetDebtWithCategoriesAsync(CurrentUserId);

            return _mapper.Map<List<DebtDto>>(entities);


        }

        public async Task UpdateAsync(DebtUpdateDto dto)
        {
            var entity = await  _repository.GetByIdAsync(dto.Id);
            if (entity == null || entity.AppUserId != CurrentUserId)
                throw new Exception("Borç bulunamadı veya bu işlem için yetkiniz yok.");

            _mapper.Map(dto, entity);
            _repository.Update(entity); 
            await _unitOfWork.CommitAsync();
        }
    }
}
