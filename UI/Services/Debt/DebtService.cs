
using UI.Models.Debt;
using UI.Models.Incomes;

namespace UI.Services.Debt
{
    public class DebtService : IDebtService
    {
        private readonly HttpClient _httpClient;

        public DebtService(IHttpClientFactory httpClientFactory)
        {
            // ÖNEMLİ: Program.cs'de TokenHandler eklenmiş olan istemciyi çağırıyoruz
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }
        public async Task CreateDebt(DebtCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Debt/create-debt", dto);
            response.EnsureSuccessStatusCode();

        }

        public async Task<List<DebtViewDto>> DebtAllWithCategories()
        {
            return await _httpClient.GetFromJsonAsync<List<DebtViewDto>>("api/Debt");
        }

        public async Task DeleteDebt(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Debt/delete-debt/{id}");
            response.EnsureSuccessStatusCode();
        }

        public  async Task<DebtViewDto> GetDebtWithCategoryById(int id)
        {
            return await _httpClient.GetFromJsonAsync<DebtViewDto>($"api/Debt/get-debt-category/{id}");
       
        }

        public async Task UpdateDebt(DebtUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Debt/update-debt", dto);
            response.EnsureSuccessStatusCode();
        }
    }
}
