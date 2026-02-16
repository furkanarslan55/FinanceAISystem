using AutoMapper;
using FinanceAI.Application.Features.Debts;
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
        IMapper _mapper;

        public IncomeService(IIncomeRepository incomeRepository, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            // Giriş yapan kullanıcının ID'sini Claims üzerinden güvenli bir şekilde alıyoruz
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            _currentUserId = userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        public async Task<List<IncomeDto>> GetAllByCurrentUserAsync()
        {
            var incomes = await _incomeRepository.GetIncomesWithCategoriesAsync(_currentUserId);

            // Entity -> DTO dönüşümü (Mapping)
            return incomes.Select(x => new IncomeDto {
              Id=  x.Id,
                Amount=  x.Amount,
                IncomeDate= x.IncomeDate,
                Description= x.Description,
              CategoryName = x.IncomeCategory.Name}).ToList();
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

        public async Task Update(IncomeUpdateDto dto)
        {
            var entity = await _incomeRepository.GetByIdAsync(dto.Id);
            if (entity == null || entity.AppUserId != _currentUserId)
            {
                throw new Exception("Gelir bulunamadı veya bu gelire erişim yetkiniz yok.");
            }
            var originalıd = entity.Id; // ID'yi sakla

            _mapper.Map(dto, entity); 
            entity.Id = originalıd; // ID'yi geri ata
            _incomeRepository.Update(entity);



            await _unitOfWork.CommitAsync();

        }

        public async Task<IncomeDto> GetByIdWithCategoryAsync(int id)
        {
            var entity = await _incomeRepository.GetIncomeWithCategorybyIdAsync(id);
            if (entity == null || entity.AppUserId != _currentUserId)
            {
                throw new Exception("Gelir bulunamadı veya bu gelire erişim yetkiniz yok.");
            }
            return new IncomeDto
            { 
              Id= entity.Id,
               Amount= entity.Amount,
                IncomeDate=   entity.IncomeDate,
                Description =   entity.Description,
              CategoryName  = entity.IncomeCategory.Name
            };








        }
        public async Task<IncomeDto?> GetLastIncomeAsync()
        {

            var ıncome = await _incomeRepository.GetLastRecordAsync(x => x.CreatedDate);
            return _mapper.Map<IncomeDto>(ıncome);
        }
    }
}
