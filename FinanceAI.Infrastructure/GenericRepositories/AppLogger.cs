using FinanceAI.Core.GenericInterfaces;
using Microsoft.Extensions.Logging;

namespace FinanceAI.Infrastructure.GenericRepositories
{
    public class AppLogger<T> : IAppLogger
    {
        private readonly ILogger<T> _logger;
        public void LogError(string message, Exception ex = null)
        {
            _logger.LogError(ex, message);
        }

        public void LogInfo(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
