using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Application.AIConfigurations
{
    public interface IAIService
    {
        Task<string> GenerateAsync(string prompt);
    }
}
