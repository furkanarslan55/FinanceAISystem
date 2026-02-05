using System.Text;
using System.Text.Json;
using UI.Models.ViewModel.Income;

namespace UI.Services.Income
{
    public class IncomeService : IIncomeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IncomeService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            // JWT token session'dan alınıyor
            var token = _httpContextAccessor.HttpContext?.Session.GetString("JWT");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }

        public async Task<List<IncomeDto>> GetAllAsync()
        {
            var client = CreateClient();
            var response = await client.GetAsync("Income");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<IncomeDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<bool> CreateAsync(IncomeCreateDto dto)
        {
            var client = CreateClient();
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Income", content);
            return response.IsSuccessStatusCode;
        }
    }
}
