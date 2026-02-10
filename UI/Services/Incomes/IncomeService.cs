using UI.Models.Incomes;

namespace UI.Services.Incomes
{
    public class IncomeService : IIncomeService
    {
        private readonly HttpClient _httpClient;

        public IncomeService(IHttpClientFactory httpClientFactory)
        {
            // ÖNEMLİ: Program.cs'de TokenHandler eklenmiş olan istemciyi çağırıyoruz
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }
        public async Task CreateAsync(IncomeCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Income", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Income/delete-income/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<IncomeViewDto>> GetAllByCurrentUserAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<IncomeViewDto>>("api/Income");
        }

        public Task<IncomeViewDto> GetByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<IncomeViewDto>($"api/Income/get-income-by-id/{id}");

        }

        public async Task Update(IncomeUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Income/", dto);
            response.EnsureSuccessStatusCode();
        }
    }
}
