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

using SamProject.Managers;
using SamProject.Repositories;





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
            services.AddSingleton<IRepository, Repository>();
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTkwMDFAMzEzNjJlMzIyZTMwRU9rMDF5Mk1maWpOTTQ2OWprdVM1OFhGMHc1NE9RQ3BFUHNFc1NXWmFrND0=;MTkwMDJAMzEzNjJlMzIyZTMwSGdDLzl6eVJ2RXU3VytHM1d3VGhPYVQ5ZmlFVWRVRW85T0tVS2wzdmVEWT0=;MTkwMDNAMzEzNjJlMzIyZTMwZFNXMWRPNHJnd1d5b2RaWUNXYWhuVDFDV0VyVnJ4Q1RIV2dIZkdaNFB4cz0=;MTkwMDRAMzEzNjJlMzIyZTMwSS93OGRvT083L0hOWDRJUUYyK1BQVHhNTitFSUtxT0l6eG9mSWc4VUUvaz0=;MTkwMDVAMzEzNjJlMzIyZTMwTk8wSUJ3cWVSdzdtaUQwaGttKzd6SmNCeE9lTlFPdC9XOWlSSUdHRTVYdz0=;MTkwMDZAMzEzNjJlMzIyZTMwWEVFVnZ2MFlFZklBdWJaOTc5aUpVRlYvSStFQUdSWC9MVk8xQ1E3aG5SND0=;MTkwMDdAMzEzNjJlMzIyZTMwaWVKYXY1ZGJxSXA0djF3NkVRU0drM1R3UEFCWUliUHNzK3RXZkZqN1FoST0=;MTkwMDhAMzEzNjJlMzIyZTMwTmlHVG1CT3lvcndnaGs4T3ZHN1NabmFzY05iMGlWQ0hvZTJZby94Y0Niaz0=;MTkwMDlAMzEzNjJlMzIyZTMwZ2FBVXg4N0l4U3pBRFdWK1hha0RTS3BjaytBZ1o3Nk8xeTFZUldDWGNEQT0=");
            // 16.2.0.50sp Core // MTkwMDBAMzEzNjJlMzIyZTMwZ2FBVXg4N0l4U3pBRFdWK1hha0RTS3BjaytBZ1o3Nk8xeTFZUldDWGNEQT0=
            // 16.2.0.50sp All  // MTkwMDFAMzEzNjJlMzIyZTMwRU9rMDF5Mk1maWpOTTQ2OWprdVM1OFhGMHc1NE9RQ3BFUHNFc1NXWmFrND0=;MTkwMDJAMzEzNjJlMzIyZTMwSGdDLzl6eVJ2RXU3VytHM1d3VGhPYVQ5ZmlFVWRVRW85T0tVS2wzdmVEWT0=;MTkwMDNAMzEzNjJlMzIyZTMwZFNXMWRPNHJnd1d5b2RaWUNXYWhuVDFDV0VyVnJ4Q1RIV2dIZkdaNFB4cz0=;MTkwMDRAMzEzNjJlMzIyZTMwSS93OGRvT083L0hOWDRJUUYyK1BQVHhNTitFSUtxT0l6eG9mSWc4VUUvaz0=;MTkwMDVAMzEzNjJlMzIyZTMwTk8wSUJ3cWVSdzdtaUQwaGttKzd6SmNCeE9lTlFPdC9XOWlSSUdHRTVYdz0=;MTkwMDZAMzEzNjJlMzIyZTMwWEVFVnZ2MFlFZklBdWJaOTc5aUpVRlYvSStFQUdSWC9MVk8xQ1E3aG5SND0=;MTkwMDdAMzEzNjJlMzIyZTMwaWVKYXY1ZGJxSXA0djF3NkVRU0drM1R3UEFCWUliUHNzK3RXZkZqN1FoST0=;MTkwMDhAMzEzNjJlMzIyZTMwTmlHVG1CT3lvcndnaGs4T3ZHN1NabmFzY05iMGlWQ0hvZTJZby94Y0Niaz0=;MTkwMDlAMzEzNjJlMzIyZTMwZ2FBVXg4N0l4U3pBRFdWK1hha0RTS3BjaytBZ1o3Nk8xeTFZUldDWGNEQT0=

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

                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(path),
                    RequestPath = new PathString("/vendor")
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
