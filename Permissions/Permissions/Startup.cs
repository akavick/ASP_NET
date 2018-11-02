using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Permissions.DAL;



namespace Permissions
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Repository>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("EditPolicy", policy => policy.Requirements.Add(new SameAuthorRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationCrudHandler>();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                        options.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
                    });
        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/Error");
                app.UseExceptionHandler("/Error/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                var cid = (ClaimsIdentity)context.User.Identity;

                //if (!cid.HasClaim(c => c.Type == "TestClaim1"))
                //{
                //    cid.AddClaim(new Claim("TestClaim1", "true"));
                //}

                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }

}
