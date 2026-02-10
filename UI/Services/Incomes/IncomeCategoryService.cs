using UI.Models.Incomes;

namespace UI.Services.Incomes
{
    public class IncomeCategoryService : IIncomeCategoryService
    {
        private readonly HttpClient _httpClient;

        public IncomeCategoryService(IHttpClientFactory httpClientFactory)
        {
            // ÖNEMLİ: Program.cs'de TokenHandler eklenmiş olan istemciyi çağırıyoruz
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }

        public async Task<List<IncomeCategoryViewDto>> GetAllAsync()
        {
            // TokenHandler arka planda token'ı ekleyeceği için burada sadece URL yazıyoruz
            return await _httpClient.GetFromJsonAsync<List<IncomeCategoryViewDto>>("api/IncomeCategories");
        }

        public async Task CreateAsync(IncomeCategoryCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/IncomeCategories", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(IncomeCategoryUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/IncomeCategories/update-incomecategory", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/IncomeCategories/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IncomeCategoryViewDto> GetByIdAsync(int id)
        {
           return await _httpClient.GetFromJsonAsync<IncomeCategoryViewDto>($"api/IncomeCategories/get-id/{id}");
        }
    }
}
