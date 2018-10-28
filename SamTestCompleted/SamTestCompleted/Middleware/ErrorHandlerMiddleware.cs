using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

using SamLogger.Interfaces;



namespace SamTestCompleted.Middleware
{



    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _next;



        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }



        public async Task InvokeAsync(HttpContext context, ISamLogProcessor logger)
        {
            var user = context.User?.Identity as System.Security.Principal.WindowsIdentity ?? context.User?.Identity;
            var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
            var exception = errorFeature.Error;
            var problemDetails = new ProblemDetails { Instance = $"urn:myorganization:error:{Guid.NewGuid()}" };

            if (exception is BadHttpRequestException badHttpRequestException)
            {
                problemDetails.Title = "Invalid request";

                problemDetails.Status =
                    (int)typeof(BadHttpRequestException)
                          .GetProperty("StatusCode", BindingFlags.NonPublic | BindingFlags.Instance)
                          .GetValue(badHttpRequestException);

                problemDetails.Detail = badHttpRequestException.Message;
            }
            else
            {
                problemDetails.Title = "An unexpected error occurred!";
                problemDetails.Status = 500;
                problemDetails.Detail = exception.Demystify().ToString();
            }

            var nl = Environment.NewLine;
            var msg = $"ERROR: {problemDetails.Title}{nl}User:{nl}{user?.Name}{nl}StatusCode:{nl}{problemDetails.Status}{nl}";
            await logger.LogErrorAsync(msg, DateTime.Now, exception.Demystify());

            //context.Response.StatusCode = problemDetails.Status.Value;

            // produce some response for the caller
            //context.Response.WriteJson(problemDetails, "application/problem+json");

            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync("<h1>Error</h1>");

            //ExceptionHandlingPath = new PathString("/Home/Error");
        }



    }



}
