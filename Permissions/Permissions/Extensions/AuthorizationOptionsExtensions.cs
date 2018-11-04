using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;



namespace Permissions.Extensions
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddPolicyAndClaimRequirement(this AuthorizationOptions authorizationOptions, string name)
        {
            authorizationOptions.AddPolicy(name, policy => policy.RequireClaim(name));
        }
    }
}
