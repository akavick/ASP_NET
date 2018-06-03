using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Http;

namespace Test_001
{




    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _pattern;
        private readonly string _name;

        public TokenMiddleware(RequestDelegate next, string pattern, string name = LegalNames.TokenName)
        {
            _next = next;
            _pattern = pattern;
            _name = name;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("<h2>Hi!</h2>");
            var token = context.Request.Query[_name];
            if (token != _pattern)
            {
                await context.Response.WriteAsync("<h2>Token is invalid</h2>");
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next(context);
            }
        }
    }






}
