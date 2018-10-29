using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Diagnostics;



namespace SamTestCompleted.Extensions
{
    public static class StatusCodeContextExtensions
    {
        public static string GetStatusCode(this StatusCodeContext statusCodeContext)
        {
            return statusCodeContext.HttpContext.Response.StatusCode.ToString();
        }

        public static IIdentity GetUser(this StatusCodeContext statusCodeContext)
        {
            return statusCodeContext.HttpContext.User.Identity;
        }
    }
}
