﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;





namespace AspNetCore_01
{

    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var host = WebHost.Start("http://localhost:8080", async context =>
            //{
            //    context.Response.ContentType = "text/html; charset=utf-8";
            //    await context.Response.WriteAsync("Привет мир!");
            //}))
            //{
            //    host.WaitForShutdown();
            //}


            //var host = new WebHostBuilder()
            //           .UseKestrel()               // настраиваем веб-сервер Kestrel 
            //           .UseContentRoot(Directory.GetCurrentDirectory())    // настраиваем корневой каталог приложения
            //           .UseIISIntegration()        // обеспечиваем интеграцию с IIS
            //           .UseStartup<Startup>()    // устанавливаем главный файл приложения
            //           .Build();                   // создаем хост
            //host.Run();


            CreateWebHostBuilder(args).Build()
                                      .Run();
        }





        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                                 //.UseWebRoot("static")   // установка папки static (вместо wwwroot)
                                 .ConfigureLogging(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Trace))
                                 .UseStartup<Startup>();

            return builder;
        }
    }

}
