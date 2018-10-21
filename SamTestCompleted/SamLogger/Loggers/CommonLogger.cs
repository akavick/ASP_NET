using System;
using System.Diagnostics;
using System.Threading.Tasks;

using SamLogger.Helpers;
using SamLogger.Interfaces;





namespace SamLogger.Loggers
{





    public class CommonLogger : ISamLogger
    {
        protected readonly string SourceName;



        public CommonLogger()
        {
            SourceName = LoggerHelper.CreateSource(GetType());
        }

        public async Task LogInformation(string message)
        {
            await Log(message, EventLogEntryType.Information);
        }

        public async Task LogWarning(string message)
        {
            await Log(message, EventLogEntryType.Warning);
        }

        public async Task LogError(string message, Exception exception)
        {
            await Log($"{message}{Environment.NewLine}exception:{Environment.NewLine}{ExceptionHelper.DemystifyException(exception)}", EventLogEntryType.Error);
        }

        protected async Task Log(string message, EventLogEntryType eventLogEntryType)
        {
            await Task.Run(() =>
            {
                using (var eventLog = new EventLog(LoggerHelper.EventLogName))
                {
                    eventLog.Source = SourceName;
                    eventLog.WriteEntry(message, eventLogEntryType);
                }
            });
        }

    }





}
