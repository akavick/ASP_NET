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
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Permissions.Authorization;
using Permissions.Authorization.Handlers;
using Permissions.Middlewares;
using Permissions.DAL;
using Permissions.Extensions;


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

            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            services.AddAuthorization(options =>
            {
                options.AddPolicyAndClaimRequirement(Policies.CanCreateRequests);
                options.AddPolicyAndClaimRequirement(Policies.CanApproveRequests);
                options.AddPolicyAndClaimRequirement(Policies.CanRejectRequests);
                options.AddPolicyAndClaimRequirement(Policies.CanRejectApprovedRequests);
                options.AddPolicyAndClaimRequirement(Policies.CanApproveRejectedRequests);
                options.AddPolicyAndClaimRequirement(Policies.CanApproveThisRequest);
                options.AddPolicyAndClaimRequirement(Policies.CanAddComments);
                options.AddPolicyAndClaimRequirement(Policies.CanViewFirstPage);
                options.AddPolicyAndClaimRequirement(Policies.CanViewSecondPage);
                options.AddPolicyAndClaimRequirement(Policies.CanViewThirdPage);

                //options.AddPolicy("CanCreateRequests", policy => policy.RequireClaim("CanCreateRequests"));
                //options.AddPolicy("Founders", policy => policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));

                options.AddPolicy("ViewRequest", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        var repository = services.SingleOrDefault(s => s.ServiceType == typeof(Repository));
                        var id = (int)context.Resource;

                            //todo
                        return true;
                    });
                });
            });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("EditPolicy", policy => policy.Requirements.Add(new SameAuthorRequirement()));
            //});

            //services.AddSingleton<IAuthorizationHandler, RequestAuthorizationHandler>();
            //services.AddSingleton<IAuthorizationHandler, RequestAuthorizationCrudHandler>();

            services.AddSingleton<IAuthorizationHandler, ComponentCodeHandler>();
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            services.AddTransient<AuthorizationLogic>();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                        options.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
                    });


            services.AddDbContext<UserContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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

            app.UseMiddleware<AuthorizationMiddleware>();

            app.Use(async (context, next) =>
            {
                var cid = (ClaimsIdentity)context.User.Identity;

                cid.AddClaim("CanCreateRequests", "true");
                cid.AddClaim("CanApproveRequests", "true");
                cid.AddClaim("CanRejectRequests", "true");
                cid.AddClaim("CanAddComments", "true");
                cid.AddClaim("CanViewFirstPage", "true");
                cid.AddClaim("CanViewSecondPage", "true");
                //cid.AddOrRewriteClaim("CanRejectApprovedRequests", "true");

                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }

    }

}
