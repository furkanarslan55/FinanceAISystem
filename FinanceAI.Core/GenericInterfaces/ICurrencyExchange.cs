using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Core.GenericInterfaces
{
    public interface ICurrencyExchange
    {
        Task<List<CurrencyDto>> GetLiveRatesAsync();
    }
}
