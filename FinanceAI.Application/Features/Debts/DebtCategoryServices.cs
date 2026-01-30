using AutoMapper;
using FinanceAI.Application.Features.Incomes;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.Debts
{
    public class DebtCategoryServices :BaseService, IDebtCategoryServices
    {

        private readonly IDebtCategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DebtCategoryServices(
            IDebtCategoryRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService) : base(currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(DebtCategoryCreateDto dto)
        {
            var category = _mapper.Map<DebtCategory>(dto);
            category.AppUserId = CurrentUserId;
            await _repository.AddAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            if (category == null || category.AppUserId != CurrentUserId)
                throw new Exception("Silinmek istenen kategori bulunamadı veya yetkiniz yok.");

            _repository.Remove(category);
            await _unitOfWork.CommitAsync();
        }

        public  async Task<List<DebtCategoryDto>> GetAllByUserIdAsync()
        {
            var categories = await _repository.GetAllAsync(x => x.AppUserId == CurrentUserId);
            return _mapper.Map<List<DebtCategoryDto>>(categories);
        }

        public async Task UpdateAsync(DebtCategoryUpdateDto dto)
        {
            var category = await _repository.GetByIdAsync(dto.Id);

            // GÜVENLİK: Kategori yoksa veya başkasına aitse GlobalHandler hatayı yakalar
            if (category == null || category.AppUserId != CurrentUserId)
                throw new Exception("Kategori bulunamadı veya bu işlem için yetkiniz yok.");

            // DTO'daki verileri mevcut entity üzerine haritala
            _mapper.Map(dto, category);

            _repository.Update(category);
            await _unitOfWork.CommitAsync();
        }
    }
}
