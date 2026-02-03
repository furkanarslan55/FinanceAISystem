using AutoMapper;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities.VariableCostEntity;
using FinanceAI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.VariableCosts.VariableCostCategoryService
{
    public class VariableCostCategoryService:BaseService, IVariableCostCategoryService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVariableCostCategoryRepository _variableCostCategoryRepository;
        public  VariableCostCategoryService(ICurrentUserService currentUserService,IUnitOfWork unitOfWork,IMapper mapper ,IVariableCostCategoryRepository variableCostCategoryRepository) : base(currentUserService)
        {
            _mapper = mapper;
                _unitOfWork = unitOfWork;
            _variableCostCategoryRepository = variableCostCategoryRepository;
        }

        public async Task CreateCategory(VariableCategoryCreateDto dto)
        {
            var entity = _mapper.Map<VariableCostCategory>(dto);
            entity.AppUserId = CurrentUserId;
           await _variableCostCategoryRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategory(int categoryId)
        { 
            var entity =await _variableCostCategoryRepository.GetByIdAsync(categoryId);
            if (entity == null || entity.AppUserId != CurrentUserId)
            {
                throw new KeyNotFoundException("Variable cost category not found.");
            }
             _variableCostCategoryRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public Task<IEnumerable<string>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCategory(VariableCategoryUpdateDto dto)
        {
            var entity = await _variableCostCategoryRepository.GetByIdAsync(dto.Id);
           if(entity ==null || entity.AppUserId !=CurrentUserId)
            {
               throw new KeyNotFoundException("Variable cost category not found.");
            }

           _mapper.Map(dto, entity);
            _variableCostCategoryRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
