﻿using System;
using System.Threading.Tasks;

using ContractsLibrary.Logging;



namespace Logger.LogProcessors
{





    public class IsaMLogService : ISaMLogService
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

        public void LogInformation(string infoMessage)
        {
            LogInformationAsyncEvent?.Invoke(infoMessage, DateTime.Now);
        }

        public void LogWarning(string warningMessage)
        {
            LogWarningAsyncEvent?.Invoke(warningMessage, DateTime.Now);
        }

        public void LogError(string errorMessage, Exception exception)
        {
            LogErrorAsyncEvent?.Invoke(errorMessage, DateTime.Now, exception);
        }

        public async Task LogInformationAsync(string infoMessage, DateTime when)
        {
            await (LogInformationAsyncEvent?.Invoke(infoMessage, when) ?? Task.CompletedTask);
        }

        public async Task LogWarningAsync(string warning, DateTime when)
        {
            await (LogWarningAsyncEvent?.Invoke(warning, when) ?? Task.CompletedTask);
        }

        public async Task LogErrorAsync(string errorMessage, DateTime when, Exception exception)
        {
            await (LogErrorAsyncEvent?.Invoke(errorMessage, when, exception) ?? Task.CompletedTask);
        }

    }





}
