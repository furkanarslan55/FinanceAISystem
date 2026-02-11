using UI.Models.Debt;
using UI.Models.Incomes;

namespace UI.Services.Debt
{
    public class DebtCategoryService : IDebtCategoryService
    {
        private readonly HttpClient _httpClient;

        public DebtCategoryService(IHttpClientFactory httpClientFactory)
        {
            // ÖNEMLİ: Program.cs'de TokenHandler eklenmiş olan istemciyi çağırıyoruz
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }
        public async Task CreateAsync(DebtCategoryCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/DebtCategory", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/DebtCategory/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<DebtCategoryDto>> GetAllByUserIdAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DebtCategoryDto>>("api/DebtCategory");
        }

        public async Task UpdateAsync(DebtCategoryUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/DebtCategory/update", dto);
            response.EnsureSuccessStatusCode();
        }
    }
}
