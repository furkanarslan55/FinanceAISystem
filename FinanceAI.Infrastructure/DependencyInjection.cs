using FinanceAI.Application.AIConfigurations;
using FinanceAI.Infrastructure.AIService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient<IAIService, OllamaAIService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:11434");
            });

            return services;
        }
    }
}
