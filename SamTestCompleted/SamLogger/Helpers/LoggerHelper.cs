using System;
using System.Diagnostics;





namespace SamLogger.Helpers
{





    public static class LoggerHelper
    {
        public const string EventLogName = "Application";



        public static string CreateSource(Type loggerType)
        {
            //var sourceName = $"{loggerType.Name}Source";
            var sourceName = "SamTestCompletedSource";
            

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, EventLogName);
            }

            return sourceName;
        }


    }





}