using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;





namespace AspNetCore_01
{

    public class Startup
    {
        private readonly string _nl = Environment.NewLine;
        private readonly IHostingEnvironment _env;





        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }





        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDirectoryBrowser();
        }





        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory lf)
        {
            //https://metanit.com/sharp/aspnet5/2.2.php

            //lf.AddConsole(LogLevel.Debug, true); // https://metanit.com/sharp/aspnet5/2.10.php

            //lf.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            //var logger = lf.CreateLogger("FileLogger");

            //lf.AddEventSourceLogger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }

            app.Map("/home", home =>
            {
                home.Map("/index", Index);
                home.MapWhen(c => c.Request.Path.Value.Contains("/about"), About);
            });

            //// например http://localhost:55234/?id=5 или http://localhost:55234/product?id=5&name=phone, 
            //app.MapWhen(context => context.Request.Query.ContainsKey("id") && context.Request.Query["id"] == "5", HandleId);



            //// https://metanit.com/sharp/aspnet5/2.18.php
            //app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware<RoutingMiddleware>();


            //app.UseDefaultFiles(); // https://metanit.com/sharp/aspnet5/2.14.php

            //var options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear(); // удаляем имена файлов по умолчанию
            //options.DefaultFileNames.Add("hello.html"); // добавляем новое имя файла
            //app.UseDefaultFiles(options); // установка параметров

            app.UseStaticFiles();

            // установка аутентификации пользователя на основе куки
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            //https://metanit.com/sharp/aspnet5/2.8.php
            app.UseOwin(pipeline =>
            {
                pipeline(next => 
                (
                    environment =>
                    {
                        // определяем ответ
                        var responseText = "Hello ASP.NET Core";

                        // кодируем его в массив байтов
                        var responseBytes = Encoding.UTF8.GetBytes(responseText);

                        // получаем поток ответа
                        var responseStream = (Stream)environment["owin.ResponseBody"];

                        // отправка ответа
                        return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
                    }
                ));
            });


            //var x = 0;
            //var firstRun = true;

            //void increment(HttpContext context)
            //{
            //    if (!firstRun && context.Request.Path.Value != "/favicon.ico") //Chrome struggling
            //    {
            //        ++x;
            //    }
            //}

            //void useIncrement()
            //{
            //    app.Use(async (context, next) =>
            //    {
            //        //https://metanit.com/sharp/aspnet5/2.3.php

            //        increment(context);

            //        await context.Response.WriteAsync(MethodBase.GetCurrentMethod().Name.Div());
            //        await context.Response.WriteAsync(GetCaller().Div());
            //        await context.Response.WriteAsync(GetCurrentMethod().Div());

            //        if (next != null)
            //        {
            //            await next.Invoke();
            //        }

            //        //increment(context); // ! продолжаем здесь после Run
            //    });
            //}

            //useIncrement();
            //useIncrement();

            //var validToken = "123";
            //app.UseToken(validToken);

            app.Run(async context =>
            {
                // создаем объект логгера
                var logger = lf.CreateLogger("RequestInfoLogger");
                // пишем на консоль информацию
                logger.LogInformation("Processing request {0}", context.Request.Path);


                //increment(context);

                //await Task.Delay(3000); // можно поставить задержку

                //await context.Response.WriteAsync($"Result: {x}");

                await context.Response.WriteAsync($"{_nl}{_env == env}");

                //await context.Response.WriteAsync($"{_nl}{firstRun}");

                //firstRun = false;

                await context.Response.WriteAsync("End".Header());

                //await Task.FromResult<object>(null);
            });
        }





        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Index".Header()));
        }





        private static void About(IApplicationBuilder about)
        {
            about.Run(async context => await context.Response.WriteAsync("About".Header()));
        }





        private static void HandleId(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("id is equal to 5");
            });
        }





        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            var currentMethod = new StackTrace().GetFrame(1).GetMethod().Name;

            return currentMethod;
        }





        public string GetCaller([CallerMemberName] string memberName = "")
        {
            return memberName;
        }

    }

}
