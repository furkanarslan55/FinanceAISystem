using Newtonsoft.Json;
using System.Text;
using UI.Models.ViewModel.Income;

namespace UI.Services.Income
{
    public class IncomeCategoryService : IIncomeCategoryService
    {
        private readonly HttpClient _httpClient;

        // IHttpClientFactory kullanarak Program.cs'de yapılandırdığımız "ApiClient"ı çağırıyoruz.
        // Bu sayede JwtHandler otomatik olarak devreye girer.
        public IncomeCategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<List<IncomeCategoryViewDto>> GetAllAsync()
        {
            // Artık AddAccessTokenToHeader() çağırmana gerek yok! 
            // JwtHandler bu işi arka planda hallediyor.
            var response = await _httpClient.GetAsync("IncomeCategories");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<IncomeCategoryViewDto>>(jsonData);
            }
            return new List<IncomeCategoryViewDto>();
        }

        public async Task CreateAsync(IncomeCategoryCreateDto model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("IncomeCategories", content);
        }

        public async Task UpdateAsync(IncomeCategoryUpdateDto model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("IncomeCategories", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"IncomeCategories/{id}");
        }
    }
}