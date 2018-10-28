using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;





namespace SamTestCompleted.Middleware
{





    public class BrowserConstrainterMiddleware
    {

        private readonly RequestDelegate _next;



        public BrowserConstrainterMiddleware(RequestDelegate next)
        {
            _next = next;
        }



        public async Task InvokeAsync(HttpContext context)
        {
            string userAgent = context.Request.Headers["User-Agent"];

            if (userAgent.Contains("MSIE") || userAgent.Contains("Trident"))
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<h1>Error: your browser is not supported</h1>");
            }
            else
            {
                await _next.Invoke(context);
            }
        }


    }





}
