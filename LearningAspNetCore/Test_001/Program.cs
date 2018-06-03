using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Test_001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ////при таком запуске - запросы из браузера вводить вручную
            //using (var host = WebHost.Start("http://localhost:8080", 
            //    async context => await context.Response.WriteAsync("Hello from WebHost!")))
            //{
            //    Console.WriteLine("STARTED");
            //    host.WaitForShutdown();
            //}


            //new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build()
            //    .Run();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
