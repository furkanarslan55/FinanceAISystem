using AutoMapper;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities.FixedCostEntity;
using FinanceAI.Core.Entities.FixedCostsEntity;
using FinanceAI.Core.Interfaces;

namespace FinanceAI.Application.Features.FixedCosts
{
    public class FixedCostCategoryService : BaseService, IFixedCostCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFixedCostCategoryRepository _repository;
        public FixedCostCategoryService(ICurrentUserService currentUserService,IUnitOfWork unitOfWork, IMapper mapper, IFixedCostCategoryRepository fixedCostCategoryRepository) : base(currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = fixedCostCategoryRepository;


        }

        public async Task CreateAsync(FixedCostCategoryCreateDto dto)
        {
            var entity = _mapper.Map<FixedCostCategory>(dto);
            entity.AppUserId= CurrentUserId;
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null || category.AppUserId != CurrentUserId)
            {
                throw new KeyNotFoundException("Fixed cost category not found.");
            }
            _repository.Remove(category);
            await _unitOfWork.CommitAsync();

        }

        public async Task<List<FixedCostCategoryViewDto>> GetAllByUserIdAsync()
        {
            var categories = await _repository.GetAllAsync(x =>x.AppUserId ==CurrentUserId);
            return _mapper.Map<List<FixedCostCategoryViewDto>>(categories);
        }

        public async Task UpdateAsync(FixedCostCategoryUpdateDto dto)
        {
            var category = await _repository.GetByIdAsync(dto.Id);

            // GÜVENLİK: Kategori yoksa veya başkasına aitse GlobalHandler hatayı yakalar
            if (category == null || category.AppUserId != CurrentUserId)
                throw new Exception("Kategori bulunamadı veya bu işlem için yetkiniz yok.");

            // DTO'daki verileri mevcut entity üzerine haritalıyorum
            _mapper.Map(dto, category);

            _repository.Update(category);
            await _unitOfWork.CommitAsync();




        }
    }
}
