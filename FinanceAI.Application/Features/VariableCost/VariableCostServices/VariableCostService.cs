using AutoMapper;
using FinanceAI.Application.Features.VariableCosts.VariableCostServices;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities.VariableCostEntity;
using FinanceAI.Core.Interfaces;

namespace FinanceAI.Application.Features.VariableCost.VariableCostService
{
    public class VariableCostService :BaseService, IVariableCostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVariableCostRepository _variableCostRepository;
        public VariableCostService(ICurrentUserService currentUserService, IUnitOfWork unitOfWork, IVariableCostRepository variableCostRepository,IMapper mapper) : base(currentUserService)
        {
            _variableCostRepository = variableCostRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task CreateVariableCost(CreatVariableCostDto dto)
        {
            var variableCost = _mapper.Map<VariablesCosts>(dto);
            variableCost.AppUserId = CurrentUserId;
            await _variableCostRepository.AddAsync(variableCost);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteVariableCost(int id)
        {
            var entity = await _variableCostRepository.GetByIdAsync(id);

            if (entity == null || entity.AppUserId != CurrentUserId)
            {
                throw new KeyNotFoundException("Variable cost not found.");
            }
            _variableCostRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<VariableCostViewDto>> GetAllByIdVariableCost()
        {
var entity = await _variableCostRepository.GetByIdAsync(CurrentUserId);
            if(entity == null)
            {
                throw new KeyNotFoundException("Variable costs not found.");
            }
            return _mapper.Map<List<VariableCostViewDto>>(entity);

        }

        public async Task UpdateVariableCost(UpdateVariableCostDto dto)
        {
             var entity =    _mapper.Map<VariablesCosts>(dto);
            if(entity == null || entity.AppUserId != CurrentUserId)
                {
                throw new KeyNotFoundException("Variable cost not found.");
            }
            _variableCostRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
