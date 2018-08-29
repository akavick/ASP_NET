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

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTE1NTlAMzEzNjJlMzIyZTMwZ2x5R0Z1ZExrVTZXQlgwMnFNVUdBNE4xMUhBT0doSlc3b1lSc1dtZElURT0=");
            // 16.2.0.46sp Core // MTE1NTlAMzEzNjJlMzIyZTMwZ2x5R0Z1ZExrVTZXQlgwMnFNVUdBNE4xMUhBT0doSlc3b1lSc1dtZElURT0=
            // 16.2.0.46sp All  // MTE1NjJAMzEzNjJlMzIyZTMwVjJsSXAxajBBRkhEY3BzNVhONTJQRGthVVpiVWpZZUJjMUdhZkROdW5PYz0=;MTE1NjNAMzEzNjJlMzIyZTMwSHpSZUx4SUxQQ1E0ejByTTBMMVhuOFpyTXBPVW81dUZZeU00RloxQlkzUT0=;MTE1NjRAMzEzNjJlMzIyZTMwQzZiVGtoWEhNTFlvckdwUzNvV3pwYi81bXZpVnF2QTArRUZMa3hKYjIrRT0=;MTE1NjVAMzEzNjJlMzIyZTMwVFRJMFlnZDNFR1dGWmtVRWk2NmxONTh1UkJXWDJNWndSRVRBdGRXc3dSRT0=;MTE1NjZAMzEzNjJlMzIyZTMwbE9hQTI5bUhMRUVWY0VueUI2ZFZ5VUNTTUlsbXhndmEzWVNUbndKODZZUT0=;MTE1NjdAMzEzNjJlMzIyZTMwS25id0tHeitpM0RkZzNkOGNud1dOQnBrU09xZXcwSi9YRGJycHdtbytRVT0=;MTE1NjhAMzEzNjJlMzIyZTMwaTROb2c1bHExQk9jc3BFcWtFd015MWNjbVhweG5WZVU4d21HWnVSOUJ1Zz0=;MTE1NjlAMzEzNjJlMzIyZTMwYmh1cnNrQkhIdm1tZ1hpSGVDdUYvSDkxNmRvd0xCUDgzVjM4UWN3YU1ocz0=;MTE1NzBAMzEzNjJlMzIyZTMwZ2x5R0Z1ZExrVTZXQlgwMnFNVUdBNE4xMUhBT0doSlc3b1lSc1dtZElURT0=


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
