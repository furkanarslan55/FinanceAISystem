using UI.Models.FixedCost.FixedCostCategory;

namespace UI.Services.FixedCost
{
    public class FixedCostCategoryService : IFixedCostCategoryService
    {
        private readonly HttpClient _httpClient;
        public FixedCostCategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }
        public async Task CreateAsync(FixedCostCategoryCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/FixedCostCategory", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/FixedCostCategory/{id}");
            response.EnsureSuccessStatusCode();
        }

        public  async Task<List<FixedCostCategoryViewDto>> GetAllByUserIdAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<FixedCostCategoryViewDto>>("api/FixedCostCategory");
        }

        public async Task<FixedCostCategoryViewDto> GetByWithId(int id)
        {
            return await _httpClient.GetFromJsonAsync<FixedCostCategoryViewDto>($"api/FixedCostCategory/{id}");
        }

        public async Task UpdateAsync(FixedCostCategoryUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/FixedCostCategory", dto);
            response.EnsureSuccessStatusCode();
        }
    }
}
