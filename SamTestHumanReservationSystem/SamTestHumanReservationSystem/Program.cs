using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SamTestHumanReservationSystem
{
    public class Program
    {


        //public static void Main(string[] args)
        //{
        //    var webHost = new WebHostBuilder()
        //                  .UseKestrel()
        //                  .UseContentRoot(Directory.GetCurrentDirectory())
        //                  .ConfigureAppConfiguration((hostingContext, config) =>
        //                  {
        //                      //var env = hostingContext.HostingEnvironment;
        //                      config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //                            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
        //                          ;
        //                      config.AddEnvironmentVariables();
        //                  })
        //                  .ConfigureLogging((hostingContext, logging) =>
        //                  {
        //                      logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //                      logging.AddEventLog();
        //                      //logging.AddEventSourceLogger();
        //                      //logging.AddDebug();
        //                  })
        //                  .UseStartup<Startup>()
        //                  .Build();

        //    webHost.Run();
        //}


        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .ConfigureLogging((hostingContext, logging) =>
                          {
                              logging.AddFilter("System", LogLevel.Information)
                                     .AddFilter("Microsoft", LogLevel.Information);

                              logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                              logging.AddEventLog();
                              
                          })
                          .UseStartup<Startup>();
        }
    }
}
