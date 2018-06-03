using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;





namespace AspNetCore_01
{
    public class TestMiddleware /* : IMiddleware*/
    {
        private readonly RequestDelegate _next;
        private readonly string _pattern;





        public TestMiddleware(RequestDelegate next, string pattern = "")
        {
            _next = next;
            _pattern = pattern ?? "";
        }





        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await Method(context);
        }





        //public async Task Invoke(HttpContext context, RequestDelegate next)
        //{
        //    await Method(context);
        //}





        private async Task Method(HttpContext context)
        {
            var token = context.Request.Query["token"];

            if (token == _pattern)
            {
                context.Response.StatusCode = 403;

                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await context.Response.WriteAsync($"{token}{Environment.NewLine}"); // аяяй

                await _next.Invoke(context);
            }
        }

    }
}
