using System;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using Permissions.Authorization.Requirements;



namespace Permissions.Authorization.Handlers
{

    public class ComponentCodeHandler : AuthorizationHandler<ComponentCodeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ComponentCodeRequirement requirement)
        {
            var code = requirement.ComponentCode;

            //todo
            return Task.CompletedTask;
        }
    }

}