using System.Net.Http;
using UI.Models;

namespace UI.Services.Dashboard
{
    public class Dashboard : IDashboard

    {
        private readonly HttpClient _httpClient;

        public Dashboard(IHttpClientFactory httpClientFactory)
        {
            // ÖNEMLİ: Program.cs'de TokenHandler eklenmiş olan istemciyi çağırıyoruz
            _httpClient = httpClientFactory.CreateClient("BackendApi");
        }
        public async Task<DashboardViewModel> GetDashboardSummaryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<DashboardViewModel>("api/Generic/dashboard");
            return response ?? new DashboardViewModel();
        }
    }
}
