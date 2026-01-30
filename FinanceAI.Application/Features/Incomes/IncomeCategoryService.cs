using AutoMapper;
using FinanceAI.Application.Interfaces;
using FinanceAI.Core.Entities.Incomes;
using FinanceAI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.Features.Incomes
{
    public class IncomeCategoryService : BaseService, IIncomeCategoryService
    {
        private readonly IIncomeCategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public IncomeCategoryService(
            IIncomeCategoryRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService) : base(currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<IncomeCategoryViewDto>> GetAllByUserIdAsync()
        {
            // BaseService'den gelen CurrentUserId ile filtreleme yapıyoruz
            var categories = await _repository.GetAllAsync(x => x.AppUserId == CurrentUserId);
            return _mapper.Map<List<IncomeCategoryViewDto>>(categories);
        }

        public async Task CreateAsync(IncomeCategoryCreateDto dto)
        {
            // DTO -> Entity dönüşümü
            var category = _mapper.Map<IncomeCategory>(dto);

            // Güvenlik: Kullanıcı ID'sini doğrudan token'dan gelen değerle set ediyoruz
            category.AppUserId = CurrentUserId;

            await _repository.AddAsync(category);

            // Değişiklikleri veritabanına yansıtıyoruz
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(IncomeCategoryUpdateDto dto)
        {
            // Güncellenecek kategoriyi bul
            var category = await _repository.GetByIdAsync(dto.Id);

            // GÜVENLİK: Kategori yoksa veya başkasına aitse GlobalHandler hatayı yakalar
            if (category == null || category.AppUserId != CurrentUserId)
                throw new Exception("Kategori bulunamadı veya bu işlem için yetkiniz yok.");

            // DTO'daki verileri mevcut entity üzerine haritala
            _mapper.Map(dto, category);

            _repository.Update(category);
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
    }
}
