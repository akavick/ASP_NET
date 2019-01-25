using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using SamAppDemo.Managers;
using SamAppRepository.Repositories;

namespace SamAppDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<IManager, Manager>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // 16.4.0.48 js + core // NjI4NDBAMzEzNjJlMzQyZTMwajE0c2tCNDVoYVd0WmJPeFJkaWJIUXRSaDZ6Yi9BWTN0WGpDQkV6MWxmaz0=;NjI4NDFAMzEzNjJlMzQyZTMwZU9VTG9NblVKOEozaFRoU3BGUmoxRHpDVHVqd1BzYlgrRFh5cGxtMHRTbz0=
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjI4NDBAMzEzNjJlMzQyZTMwajE0c2tCNDVoYVd0WmJPeFJkaWJIUXRSaDZ6Yi9BWTN0WGpDQkV6MWxmaz0=;NjI4NDFAMzEzNjJlMzQyZTMwZU9VTG9NblVKOEozaFRoU3BGUmoxRHpDVHVqd1BzYlgrRFh5cGxtMHRTbz0=");

            app.UseDeveloperExceptionPage();

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

            if (env.IsDevelopment())
            {
                //var path = Path.Combine(Directory.GetCurrentDirectory(), @"node_modules");
                var path = @"D:\Git\Source\Repos\ASP_NET\SamAppDemo\SamAppDemo\node_modules";
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(path),
                    RequestPath = new PathString("/node_modules")
                });
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
