﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

using Newtonsoft.Json.Serialization;

using SamLogger.Interfaces;
using SamLogger.Loggers;
using SamLogger.LogProcessors;





namespace SamTestCompleted
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<ISamLogProcessor, CommonSamLogProcessor>();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure
        (
            IApplicationBuilder applicationBuilder
          , IHostingEnvironment hostingEnvironment
          , ISamLogProcessor logger
        )
        {
            var loggingSection = Configuration.GetSection("Logging");
            var sourceName = loggingSection["SourceName"];
            var logName = loggingSection["LogName"];
            logger.Subscribe(new CommonSamEventLogLogger(sourceName, logName));


            if (hostingEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }
            else
            {
                applicationBuilder.UseExceptionHandler("/Home/Error");
                applicationBuilder.UseHsts();
            }



            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseCookiePolicy();

            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute(
                                name: "default",
                                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

}
