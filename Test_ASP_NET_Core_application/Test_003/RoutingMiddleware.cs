using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Test_003
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;



        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }



        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower(); // http://server:port{/home/index}?param=value      //{path}
            switch (path)
            {
                case "/":
                case "/index":
                {
                    await context.Response.WriteAsync("<h1>HomePage</h1>");
                    break;
                }
                case "/about":
                {
                    await context.Response.WriteAsync("<h1>About</h1>");
                    break;
                }
                default:
                {
                    context.Response.StatusCode = 404;
                    break;
                }
            }
        }


    }
}
