using AutoMapper;
using FinanceAI.Application.Interfaces;
using FinanceAI.Business.Features.Incomes;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Entities.DebtEntity;
using FinanceAI.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceAI.Application.Features.Debts
{
    public class DebtServices : IDebtServices
    {
        private readonly IDebtRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int CurrentUserId;

        public DebtServices(
           IDebtRepository debtRepository,IUnitOfWork unitOfWork,IMapper mapper, IHttpContextAccessor httpContextAccessor) 
        {
            _repository = debtRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            // Giriş yapan kullanıcının ID'sini Claims üzerinden güvenli bir şekilde alıyoruz
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            CurrentUserId = userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;

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
            var entity = await  _repository.GetByIdAsync(id);
            if (entity == null || entity.AppUserId != CurrentUserId)
                throw new Exception("Borç bulunamadı veya bu işlem için yetkiniz yok.");
            _repository.Remove(entity); //silme işlemleri asenkron olmayabilir
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<DebtDto>> GetAllByUserIdAsync()
        {
            
            var entities = await _repository.GetDebtWithCategoriesAsync(CurrentUserId);

            //return _mapper.Map<List<DebtDto>>(entities);
            return entities.Select(x => new DebtDto(
                x.Id,
                x.Name,
                x.Amount,
                x.DueDate,
                x.Description,
                x.DebtCategory.Name)).ToList();

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
