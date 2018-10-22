using System;
using System.Diagnostics;
using System.Threading.Tasks;

using SamLogger.Interfaces;





namespace SamLogger.Loggers
{





    public class CommonSamEventLogLogger : ISamEventLogLogger
    {
        protected string SourceName;
        protected string LogName;



        public CommonSamEventLogLogger(string sourceName, string logName)
        {
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }

            SourceName = sourceName;
            LogName = logName;
        }



        public async Task LogInformationAsync(string message, DateTime when)
        {
            await Log(message, EventLogEntryType.Information);
        }



        public async Task LogWarningAsync(string message, DateTime when)
        {
            await Log(message, EventLogEntryType.Warning);
        }



        public async Task LogErrorAsync(string message, DateTime when, Exception exception)
        {
            await Log($"{message}{Environment.NewLine}exception:{Environment.NewLine}{exception.Demystify()}", EventLogEntryType.Error);
        }



        protected async Task Log(string message, EventLogEntryType eventLogEntryType)
        {
            await Task.Run(() =>
            {
                using (var eventLog = new EventLog(LogName))
                {
                    eventLog.Source = SourceName;
                    eventLog.WriteEntry(message, eventLogEntryType);
                }
            });
        }



    }



}
