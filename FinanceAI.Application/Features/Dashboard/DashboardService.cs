using FinanceAI.Core.GenericInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinanceAI.Core.GenericInterfaces.ICurrencyExchange;

namespace FinanceAI.Application.Features.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly ICurrencyExchange _currencyService;

        public DashboardService(ICurrencyExchange currencyService)
        {
            _currencyService = currencyService;
        }
        public async Task<List<CurrencyDto>> GetDashboardRatesAsync()
        {
            var data = await _currencyService.GetLiveRatesAsync();

            return data; // Şimdilik olduğu gibi dönüyoruz.
        }
    }
}
