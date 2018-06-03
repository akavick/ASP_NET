using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Test_007.Services;

namespace Test_007
{
    public class CounterMiddleware
    {
        private int _i = 0;

        public CounterMiddleware(RequestDelegate next)
        {
            
        }

        public async Task InvokeAsync(HttpContext context, ICounter counter, CounterService counterService)
        {
            await context.Response.WriteAsync($"Request: {++_i} ICounter: {counter.Value} CounterService: {counterService.Counter.Value}");
        }

    }
}
