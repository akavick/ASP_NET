using System;
using System.Threading.Tasks;

using SamLogger.Interfaces;





namespace SamLogger.LogProcessors
{





    public class BasicLogProcessor : ISamLogProcessor
    {
        private event Func<string, Task> LogInformationEvent;
        private event Func<string, Task> LogWarningEvent;
        private event Func<string, Exception, Task> LogErrorEvent;



        public void Subscribe(ISamLogger logger)
        {
            LogInformationEvent += logger.LogInformation;
            LogWarningEvent += logger.LogWarning;
            LogErrorEvent += logger.LogError;
        }

        public void Unsubscribe(ISamLogger logger)
        {
            LogInformationEvent -= logger.LogInformation;
            LogWarningEvent -= logger.LogWarning;
            LogErrorEvent -= logger.LogError;
        }

        public async Task LogInformation(string message)
        {
            if (LogInformationEvent != null)
                await LogInformationEvent(message);
        }

        public async Task LogWarning(string message)
        {
            if (LogWarningEvent != null)
                await LogWarningEvent(message);
        }

        public async Task LogError(string message, Exception exception)
        {
            if (LogErrorEvent != null)
                await LogErrorEvent(message, exception);
        }

    }





}
