using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;





namespace AspNetCore_01
{

    public class TokenMiddleware/* : IMiddleware*/ //TODO: почему не работает через интефейс?
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
            await context.Response.WriteAsync("Hi!".Header(2));

            var token = context.Request.Query[_name];

            if (token != _pattern)
            {
                await context.Response.WriteAsync("Token is invalid".Header(2));

                context.Response.StatusCode = 403;
            }
            else
            {
                await _next(context);
            }
        }





        //public Task InvokeAsync(HttpContext context, RequestDelegate next = null)
        //{
        //    var task = Task.Run(async () =>
        //    {
        //        await context.Response.WriteAsync("Hi!".Header(2));

        //        var token = context.Request.Query[_name];

        //        if (token != _pattern)
        //        {
        //            await context.Response.WriteAsync("Token is invalid".Header(2));

        //            context.Response.StatusCode = 403;
        //        }
        //        else
        //        {
        //            await _next(context);
        //        }
        //    });

        //    return task;
        //}
    }

}