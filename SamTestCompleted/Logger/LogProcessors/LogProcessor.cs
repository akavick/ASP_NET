using System;
using System.Threading.Tasks;

using ContractsLibrary.Logging;



namespace Logger.LogProcessors
{





    public class LogProcessor : ILogProcessor
    {
        private event Func<string, DateTime, Task> LogInformationAsyncEvent;
        private event Func<string, DateTime, Task> LogWarningAsyncEvent;
        private event Func<string, DateTime, Exception, Task> LogErrorAsyncEvent;



        public void Subscribe(ILogger logger)
        {
            LogInformationAsyncEvent += logger.LogInformationAsync;
            LogWarningAsyncEvent += logger.LogWarningAsync;
            LogErrorAsyncEvent += logger.LogErrorAsync;
        }

        public void Unsubscribe(ILogger logger)
        {
            LogInformationAsyncEvent -= logger.LogInformationAsync;
            LogWarningAsyncEvent -= logger.LogWarningAsync;
            LogErrorAsyncEvent -= logger.LogErrorAsync;
        }

        public void LogInformation(string message)
        {
            LogInformationAsyncEvent?.Invoke(message, DateTime.Now);
        }

        public void LogWarning(string message)
        {
            LogWarningAsyncEvent?.Invoke(message, DateTime.Now);
        }

        public void LogError(string message, Exception exception)
        {
            LogErrorAsyncEvent?.Invoke(message, DateTime.Now, exception);
        }

        public async Task LogInformationAsync(string message, DateTime when)
        {
            await (LogInformationAsyncEvent?.Invoke(message, when) ?? Task.CompletedTask);
        }

        public async Task LogWarningAsync(string message, DateTime when)
        {
            await (LogWarningAsyncEvent?.Invoke(message, when) ?? Task.CompletedTask);
        }

        public async Task LogErrorAsync(string message, DateTime when, Exception exception)
        {
            await (LogErrorAsyncEvent?.Invoke(message, when, exception) ?? Task.CompletedTask);
        }

    }





}
