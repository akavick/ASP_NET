using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

using Newtonsoft.Json.Serialization;

using SamLogger.Interfaces;
using SamLogger.Loggers;
using SamLogger.LogProcessors;

using SamTestCompleted.Helpers;
using SamTestCompleted.Middleware;



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

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddSingleton<ISamLogProcessor, CommonSamLogProcessor>();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
            //    options.AddPolicy("Founders", policy => policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
            //    options.AddPolicy("BadgeEntry", policy =>
            //                          policy.RequireAssertion(context =>
            //                                                      context.User.HasClaim(c =>
            //                                                                                (c.Type == ClaimTypes.Country ||
            //                                                                                 c.Type == ClaimTypes.DateOfBirth) &&
            //                                                                                c.Issuer == "https://microsoftsecurity")));
            //});
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


            applicationBuilder.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/html";
                await context.HttpContext.Response.WriteAsync($"<h1>Error {context.HttpContext.Response.StatusCode}</h1>");
            });
            //todo выбрать вариант
            //app.UseStatusCodePagesWithReExecute("/html/errors/{0}.html");

            // todo убрать IE на уровне сервера?
            applicationBuilder.UseMiddleware<BrowserConstrainterMiddleware>();

            //if (hostingEnvironment.IsDevelopment())
            //{
            //    applicationBuilder.UseBrowserLink();
            //    applicationBuilder.UseDeveloperExceptionPage();
            //    applicationBuilder.UseDatabaseErrorPage();
            //}
            //else
            {
                applicationBuilder.UseExceptionHandler(errorApplicationBuilder => errorApplicationBuilder.UseMiddleware<ErrorHandlerMiddleware>());
                //applicationBuilder.UseExceptionHandler("/Home/Error");
                //applicationBuilder.UseExceptionHandler(Helper.GetExceptionHandlerOptions(logger, mailHandler));
                applicationBuilder.UseHsts();
            }


            //applicationBuilder.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        var user = (WindowsIdentity)context.User.Identity;
            //        await context.Response
            //                     .WriteAsync($"User: {user.Name}\tState: {user.ImpersonationLevel}\n");
            //        //Note that RunImpersonated doesn't support asynchronous operations and shouldn't be used for complex scenarios. For example, wrapping entire requests or middleware chains isn't supported or recommended.
            //        WindowsIdentity.RunImpersonated(user.AccessToken, () =>
            //        {
            //            var impersonatedUser = WindowsIdentity.GetCurrent();
            //            var message =
            //                $"User: {impersonatedUser.Name}\tState: {impersonatedUser.ImpersonationLevel}";
            //            var bytes = Encoding.UTF8.GetBytes(message);
            //            context.Response.Body.Write(bytes, 0, bytes.Length);
            //        });
            //    }
            //    catch (Exception e)
            //    {
            //        await context.Response.WriteAsync(e.ToString());
            //    }
            //});



            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseCookiePolicy();
            applicationBuilder.UseAuthentication();
            applicationBuilder.UseMvcWithDefaultRoute();

            //applicationBuilder.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //                    name: "default",
            //                    template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }

}
