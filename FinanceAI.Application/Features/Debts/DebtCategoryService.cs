using AutoMapper;
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
    public class DebtCategoryService : BaseService, IDebtCategoryServices
    {
        private readonly IDebtCategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DebtCategoryService(
                    ICurrentUserService currentUserService, IDebtCategoryRepository debtCategoryRepository,IUnitOfWork unitOfWork,IMapper mapper) : base(currentUserService)
        {
            _repository = debtCategoryRepository;
            


        }

        public async Task CreateAsync(DebtCategoryCreateDto dto)
        {
           var entity = _mapper.Map<DebtCategory>(dto);

            entity.AppUserId = CurrentUserId;

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();


        }

        public async Task DeleteAsync(int id)
        {
         var entity = await _repository.GetByIdAsync(id);
            if (entity == null || entity.AppUserId != CurrentUserId)
                throw new Exception("Borç kategorisi bulunamadı veya bu işlem için yetkiniz yok.");
            _repository.Remove(entity); //silme işlemleri asenkron olmayabilir
          await  _unitOfWork.CommitAsync();
       
        }

        public async Task<List<DebtCategoryDto>> GetAllByUserIdAsync()
        {
           var entity =  await _repository.GetByIdAsync(CurrentUserId);
            return _mapper.Map<List<DebtCategoryDto>>(entity);

        }

        public async Task UpdateAsync(DebtCategoryUpdateDto dto)
        {
        var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null || entity.AppUserId != CurrentUserId)
                throw new Exception("Borç kategorisi bulunamadı veya bu işlem için yetkiniz yok.");
            _mapper.Map(dto, entity);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();


        }
    }
}
