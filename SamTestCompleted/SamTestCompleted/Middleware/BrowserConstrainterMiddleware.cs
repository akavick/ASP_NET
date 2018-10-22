using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;





namespace SamTestCompleted.Middleware
{





    public class BrowserConstrainterMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string userAgent = context.Request.Headers["User-Agent"];

            if (userAgent.Contains("MSIE") || userAgent.Contains("Trident"))
            {
                await context.Response.WriteAsync("Your browser is not supported");
            }
            else
            {
                await next.Invoke(context);
            }
        }





    }





}
