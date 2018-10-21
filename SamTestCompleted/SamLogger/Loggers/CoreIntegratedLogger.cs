using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using SamLogger.Helpers;
using SamLogger.Interfaces;





namespace SamLogger.Loggers
{
    public class CoreIntegratedLogger : ISamLogger
    {

        private readonly ILogger<CoreIntegratedLogger> _logger;

        public string SourceName { get; }



        public CoreIntegratedLogger(ILogger<CoreIntegratedLogger> logger)
        {
            _logger = logger;
            SourceName = LoggerHelper.CreateSource(GetType());
        }

        public async Task LogInformation(string message)
        {
            await Task.Run(() =>
            {
                _logger.LogInformation(message);
            });
        }

        public async Task LogWarning(string message)
        {
            await Task.Run(() =>
            {
                _logger.LogWarning(message);
            });
        }

        public async Task LogError(string message, Exception exception)
        {
            await Task.Run(() =>
            {
                _logger.LogError(exception, message);
            });
        }

    }
}
