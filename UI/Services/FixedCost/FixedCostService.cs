using System.Net.Http;
using UI.Models.FixedCost;

namespace UI.Services.FixedCost
{
    public class FixedCostService : IFixedCostService
    {

        private readonly HttpClient _httpClient;

        public FixedCostService(IHttpClientFactory httpClientFactory)
        {
            // ÖNEMLİ: Program.cs'de TokenHandler eklenmiş olan istemciyi çağırıyoruz
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }
        public async Task CreateAsync(FixedCostCreateDto dto)
        {
            var createdFixedCost = await _httpClient.PostAsJsonAsync("api/FixedCost", dto);
           createdFixedCost.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
           var response = await _httpClient.DeleteAsync($"api/FixedCost/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<FixedCostDto>> GetAllWithCategoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<FixedCostDto>>("api/FixedCost/all-fixedcost");
        }

        public async Task<FixedCostDto> GetByIdWithCategoryAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<FixedCostDto>($"api/FixedCost/{id}");
        }

        public async Task UpdateAsync(int id, FixedCostUpdateDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/FixedCost/{id}", dto);
        }
    }
}
