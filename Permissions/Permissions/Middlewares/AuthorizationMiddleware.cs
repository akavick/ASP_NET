using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Permissions.Authorization;



namespace Permissions.Middlewares
{



    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly AuthorizationLogic _authorizationLogic;



        public AuthorizationMiddleware(RequestDelegate next, AuthorizationLogic authorizationLogic)
        {
            _next = next;
            _authorizationLogic = authorizationLogic;
        }



        public async Task InvokeAsync(HttpContext context)
        {
            _authorizationLogic.SetMyPermissions(context.User.Identity);

            await _next.Invoke(context);
        }
    }



}
