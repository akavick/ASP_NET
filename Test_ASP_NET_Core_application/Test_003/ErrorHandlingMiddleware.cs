using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Test_003
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;



        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }



        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            switch (context.Response.StatusCode)
            {
                case 403:
                {
                    await context.Response.WriteAsync("<h1>Access denied</h1>");
                    break;
                }
                case 404:
                {
                    await context.Response.WriteAsync("<h1>Not found</h1>");
                    break;
                }
            }
        }
    }
}
