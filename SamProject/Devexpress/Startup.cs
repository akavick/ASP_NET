using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Bootstrap;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

using Newtonsoft.Json.Serialization;





namespace Devexpress
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
            //services.AddSingleton<IRepository, Repository>();
            //services.AddSingleton<IManager, Manager>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());


            // set up the services utilized by DevExpress controls 
            //services.AddDevExpressControls();
            services.AddDevExpressControls(options =>
            {
                options.Bootstrap(bootstrapOptions =>
                {
                    bootstrapOptions.IconSet = BootstrapIconSet.Embedded;
                    bootstrapOptions.Mode = BootstrapMode.Bootstrap4;
                });
                options.Resources = ResourcesType.DevExtreme;
            });
        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // register DevExpress middleware components before calling UseMvc()
            app.UseDevExpressControls();

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
            // register DevExpress middleware components before calling UseMvc()
            app.UseDevExpressControls();
            app.UseStaticFiles();

            //// Add support for node_modules but only during development **temporary**
            //if (env.IsDevelopment())
            //{
            //    var path = Path.Combine(Directory.GetCurrentDirectory(), @"node_modules");

            //    app.UseStaticFiles(new StaticFileOptions {FileProvider = new PhysicalFileProvider(path), RequestPath = new PathString("/node_modules")});
            //}

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
