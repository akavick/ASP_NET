using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Test_006
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate _next;


        public MessageMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context, MessageService ms)
        {
            await context.Response.WriteAsync($"<h2>{ms.Send()}</h2>");
            await _next(context);
        }
    }
}