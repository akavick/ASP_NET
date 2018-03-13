using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Test_001
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //var x = 1;

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //app.UseStaticFiles();
            //app.Use() // терминальный, но с возможностью передачи следующему в конвейре
            //app.Map()
            //app.UseWhen()
            //app.MapWhen()
            // app.UseMiddleware()


            app.Map("/index", index => index.Run(async context => await context.Response.WriteAsync("<h1>Index</h1>")));


            app.Map("/home", home =>
            {
                home.Map("/here", here => here.Run(async context => await context.Response.WriteAsync("<h1>Here</h1>")));
                home.Map("/about", About);
                home.Run(async context => await context.Response.WriteAsync("<h1>Home</h1>"));
            });


            app.Map("/about", About);


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync($"<div>{MethodBase.GetCurrentMethod().Name}</div>");
                await next(); // здесь будет вызван app.Run(), потому что он следующий в конвейре
                await context.Response.WriteAsync($"<div>{GetCaller()}</div>");
                await context.Response.WriteAsync($"<div>{GetCurrentMethod()}</div>");
            });

            //app.UseMiddleware<TokenMiddleware>();
            var validToken = "123";
            app.UseToken(validToken);

            //// терминальный
            //app.Run(async context => await context.Response.WriteAsync($"x = {x *= 2}"));
            app.Run(async context => await context.Response.WriteAsync("<h1>End</h1>"));
        }

        private void About(IApplicationBuilder about)
        {
            about.Run(async context => await context.Response.WriteAsync("<h1>About</h1>"));
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod() => new StackTrace().GetFrame(1).GetMethod().Name;

        public string GetCaller([CallerMemberName] string memberName = "") => memberName;
    }
}
