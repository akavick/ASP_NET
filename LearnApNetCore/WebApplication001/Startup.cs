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
	    private string _nl = Environment.NewLine;
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

			app.UseStaticFiles();

			// установка аутентификации пользователя на основе куки
			app.UseAuthentication();

			app.UseMvcWithDefaultRoute();

			var x = 0;

			void quad(HttpContext context)
			{
				if (context.Request.Path.Value != "/favicon.ico") //Chrome struggling
				{
					++x;
				}
			}


			app.Use(async (context, next) =>
			{
				quad(context);

				if (next != null)
				{
					await next.Invoke();
				}

				quad(context);
			});

			app.Run(async context =>
			{
				quad(context);

				await context.Response.WriteAsync($"Result: {x}");

				quad(context);

			    await context.Response.WriteAsync($"{_nl}{_env == env}");

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









	}

}
