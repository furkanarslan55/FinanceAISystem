using FinanceAI.Core.GenericInterfaces;
using System.Net.Http.Json;

namespace FinanceAI.Infrastructure.Services
{
    public class CurrencyExchange : ICurrencyExchange
    {
        private readonly HttpClient _httpClient;

        

        public CurrencyExchange(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CurrencyApi");
        }

        public async Task<List<CurrencyDto>> GetLiveRatesAsync()
        {
            try
            {
                // 1. API'ye isteği at (BaseAddress Program.cs'den geliyor)
                var response = await _httpClient.GetAsync("TRY");

                // 2. Başarılı mı kontrol et
                if (!response.IsSuccessStatusCode)
                    return new List<CurrencyDto>(); // Loglama yapılabilir

                // 3. JSON'u oku ve bizim geçici modelimize (ExternalCurrencyResponse) çevir
                var result = await response.Content.ReadFromJsonAsync<ExternalCurrencyResponse>();

                if (result == null || result.Rates == null)
                    return new List<CurrencyDto>();

                // 4. MAPPING: API'den gelen karmaşık yapıyı kendi DTO listemize çeviriyoruz
                // Dashboard'da sadece USD ve EUR görmek istediğimizi varsayalım
                var ratesToShow = new List<CurrencyDto>
        {
            new CurrencyDto
            {
                Symbol = "USD", 
                // Kur 1/0.032 şeklinde geldiği için tersini alıyoruz (TRY bazlı olduğu için)
                Price = Math.Round(1 / result.Rates["USD"], 2),
                Change = "Güncel"
            },
            new CurrencyDto
            {
                Symbol = "EUR",
                Price = Math.Round(1 / result.Rates["EUR"], 2),
                Change = "Güncel"
            }
        };

                return ratesToShow;
            }
            catch (Exception ex)
            {
                // Profesyonel dünyada burada mutlaka bir Logger olur (NLog, Serilog vb.)
                return new List<CurrencyDto>();
            }
        }
       
        internal class ExternalCurrencyResponse
        {
            public string Base { get; set; }
            public Dictionary<string, decimal> Rates { get; set; }
        }
    }
}
