using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;





namespace WebApplication001
{

    public class Startup
    {
        private readonly string _nl = Environment.NewLine;
        private readonly IHostingEnvironment _env;





        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }





        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.Add(,)
        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory lf)
        {
            //https://metanit.com/sharp/aspnet5/2.2.php

            //lf.AddConsole(LogLevel.Debug, true);

            lf.AddEventSourceLogger();

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

            // например http://localhost:55234/?id=5 или http://localhost:55234/product?id=5&name=phone, 
            app.MapWhen(context => context.Request.Query.ContainsKey("id") && context.Request.Query["id"] == "5", HandleId);

            app.UseStaticFiles();

            // установка аутентификации пользователя на основе куки
            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            //app.UseMiddleware<MyMiddleware>();
            app.UseMyMiddleware(); // расширение

            var x = 0;
            var firstRun = true;

            void increment(HttpContext context)
            {
                if (!firstRun && context.Request.Path.Value != "/favicon.ico") //Chrome struggling
                {
                    ++x;
                }
            }

            void useIncrement()
            {
                app.Use(async (context, next) =>
                {
                    //https://metanit.com/sharp/aspnet5/2.3.php

                    increment(context);

                    if (next != null)
                    {
                        await next.Invoke();
                    }

                    //increment(context); // ! продолжаем здесь после Run
                });
            }

            useIncrement();
            useIncrement();

            app.Run(async context =>
            {
                increment(context);

                //await Task.Delay(3000); // можно поставить задержку

                await context.Response.WriteAsync($"Result: {x}");

                //await context.Response.WriteAsync($"{_nl}{_env == env}");

                await context.Response.WriteAsync($"{_nl}{firstRun}");

                firstRun = false;

                await Task.FromResult<object>(null);
            });
        }







        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Index"));
        }





        private static void About(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("About"));
        }





        private static void HandleId(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("id is equal to 5");
            });
        }



    }

}
