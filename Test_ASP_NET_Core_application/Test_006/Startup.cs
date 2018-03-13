using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Test_006.Services;

namespace Test_006
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, MessageSender>();
            services.AddTransient<TimeService>();

            services.AddTransient<MessageService>(); // в конструктор этого класса IMessageSender попадает без моего участия?
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IMessageSender sender, TimeService timer, MessageService ms)
        {
            app.UseMiddleware<MessageMiddleware>();


            app.Run(async context =>
            {
                await context.Response.WriteAsync($"{sender.Send()}&{ms.Send()} at {timer.GetTime()}");

                var serv = context.RequestServices.GetService<MessageService>(); // null если не найдёт
                //var serv = context.RequestServices.GetRequiredService<MessageService>(); // throws
                await context.Response.WriteAsync($"{serv?.Send()}");
            });
        }
    }
}
