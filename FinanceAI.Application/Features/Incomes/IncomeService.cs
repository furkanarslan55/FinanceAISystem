using FinanceAI.Business.Features.Incomes;
using FinanceAI.Core.Entities;
using FinanceAI.Core.Entities.Incomes;
using FinanceAI.Core.Interfaces;
using FinanceAI.Infrastructure.Features.Incomes;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceAI.Application.Features.Incomes
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int _currentUserId;
        private readonly IUnitOfWork _unitOfWork;

        public IncomeService(IIncomeRepository incomeRepository, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _incomeRepository = incomeRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;

            // Giriş yapan kullanıcının ID'sini Claims üzerinden güvenli bir şekilde alıyoruz
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            _currentUserId = userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        public async Task<List<IncomeDto>> GetAllByCurrentUserAsync()
        {
            var incomes = await _incomeRepository.GetIncomesWithCategoriesAsync(_currentUserId);

            // Entity -> DTO dönüşümü (Mapping)
            return incomes.Select(x => new IncomeDto(
                x.Id,
                x.Amount,
                x.IncomeDate,
                x.Description,
                x.IncomeCategory.Name)).ToList();
        }

        public async Task CreateAsync(IncomeCreateDto dto)
        {
            var income = new Income
            {
                Amount = dto.Amount,
                IncomeDate = dto.Date,
                Description = dto.Description,
                IncomeCategoryId = dto.IncomeCategoryId,
                AppUserId = _currentUserId // Kural: Veri her zaman mevcut kullanıcıya bağlanır
            };

            await _incomeRepository.AddAsync(income);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _incomeRepository.GetByIdAsync(id);
            if( id == null|| entity.AppUserId != _currentUserId )
            {

                throw new Exception("Gelir bulunamadı veya bu gelire erişim yetkiniz yok.");

            }
             _incomeRepository.Remove(entity);
            await _unitOfWork.CommitAsync();

        }
    }
}
