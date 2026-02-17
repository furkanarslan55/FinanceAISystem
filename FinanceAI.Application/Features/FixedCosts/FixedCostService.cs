using AutoMapper;
using FinanceAI.Application.Interfaces;
using FinanceAI.Business.Features.Incomes;
using FinanceAI.Core.Entities.FixedCostEntity;
using FinanceAI.Core.Interfaces;
using FinanceAI.Infrastructure.Features.Incomes;

namespace FinanceAI.Application.Features.FixedCosts
{
    public class FixedCostService :BaseService ,IFixedCostService
    {
        private readonly IFixedCostRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FixedCostService(ICurrentUserService currentUserService,IFixedCostRepository fixedCostRepository,IMapper mapper , IUnitOfWork unitOfWork) : base(currentUserService)
        {
            _repository = fixedCostRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task CreateAsync(FixedCostCreateDto dto)
        {
            var entity = _mapper.Map<FixedCost>(dto);
            entity.AppUserId = CurrentUserId;
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null || entity.AppUserId != CurrentUserId)
                throw new Exception("Fixed cost not found or access denied.");
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<FixedCostDto>> GetAllWithCategoryAsync()
        {
            var entities =  await _repository.GetFixedCostWithCategoriesAsync(CurrentUserId);
            return _mapper.Map<List<FixedCostDto>>(entities);

        }

        public async Task<FixedCostDto> GetByIdWithCategoryAsync(int id)
        {
            var entity =await _repository.GetFixedCostWithCategoryByIdAsync(id);
                        if (entity == null || entity.AppUserId != CurrentUserId)
                throw new Exception("Fixed cost not found or access denied.");

                       return new FixedCostDto
                       {
                           Id = entity.Id,
                           Name = entity.Name,
                           Amount = entity.Amount,
                           CategoryName = entity.FixedCostCategory.Name
                       };
        }

        public async Task<FixedCostDto> GetLastFixedCostAsync()
        {
            var ıncome = await _repository.GetLastRecordAsync(x => x.AppUserId==CurrentUserId,x=>x.CreatedDate);
            return _mapper.Map<FixedCostDto>(ıncome);
        }

        public async Task UpdateAsync(int id, FixedCostUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null || entity.AppUserId != CurrentUserId)
                throw new Exception("Fixed cost not found or access denied.");
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
