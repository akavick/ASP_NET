using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using Newtonsoft.Json.Serialization;

using Repository.Repositories;

using SamProject.Managers;





namespace SamProject
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }





        public IConfiguration Configuration { get; }





        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository, Repository.Repositories.Repository>();
            services.AddSingleton<IManager, Manager>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzIyMDdAMzEzNjJlMzMyZTMwS1lBeTREaDNHaEhJZFVSWjJRMms0NUlGdGsrVjBQdkpFbVhmT2gxZVd6MD0=;MzIyMDhAMzEzNjJlMzMyZTMwbW03M0N0cmZGZzUvcC9nYitQaVNrZDhLajM1VGRrZWU5M3F0NTdjamRwOD0=");
            // 16.3.0.21 js + core // MzIyMDdAMzEzNjJlMzMyZTMwS1lBeTREaDNHaEhJZFVSWjJRMms0NUlGdGsrVjBQdkpFbVhmT2gxZVd6MD0=;MzIyMDhAMzEzNjJlMzMyZTMwbW03M0N0cmZGZzUvcC9nYitQaVNrZDhLajM1VGRrZWU5M3F0NTdjamRwOD0=

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //if (env.IsDevelopment())
            //{
            //    app.Use(async (context, next) =>
            //    {
            //        if (context.Request.Path.Value == "/favicon.ico")
            //        {
            //            var path = new PathString("/SamProject/favicon.ico");
            //            context.Request.Path = path;
            //        }

            //        await next.Invoke();
            //    });
            //}

            app.Use(async (context, next) =>
            {
                string userAgent = context.Request.Headers["User-Agent"];

                if (userAgent.Contains("MSIE") || userAgent.Contains("Trident"))
                {
                    await context.Response.WriteAsync("Your browser is not supported");
                }
                else
                {
                    await next.Invoke();
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Add support for node_modules but only during development **temporary**
            if (env.IsDevelopment())
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), @"node_modules");

                app.UseStaticFiles(new StaticFileOptions {FileProvider = new PhysicalFileProvider(path), RequestPath = new PathString("/node_modules")});
            }

            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                                name: "default",
                                template: "{controller=Home}/{action=Index}/{number?}");
            });
        }
    }

}
