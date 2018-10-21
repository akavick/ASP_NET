using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;





namespace SamTestCompleted
{

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }





        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var webHostBuilder = 
                WebHost.CreateDefaultBuilder(args)
                       .ConfigureLogging((hostingContext, logging) =>
                       {
                           var loggingSection = hostingContext.Configuration.GetSection("Logging");
                           var sourceName = loggingSection["SourceName"];
                           var logName = loggingSection["LogName"];
                     
                           if (!EventLog.SourceExists(sourceName))
                           {
                               EventLog.CreateEventSource(sourceName, logName);
                           }

                           logging.ClearProviders();
                           logging.AddConfiguration(loggingSection);
                           logging.AddEventLog(new EventLogSettings
                           {
                               SourceName = sourceName,
                               LogName = logName
                           });
                       })
                       .UseStartup<Startup>();

            return webHostBuilder;
        }
    }

}
