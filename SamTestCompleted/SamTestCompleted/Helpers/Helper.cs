using System;
using System.Diagnostics;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;





namespace SamTestCompleted.Helpers
{





    public static class Helper
    {
        //public static ExceptionHandlerOptions GetExceptionHandlerOptions(ILoggerHandler logger)
        //{
        //    return new ExceptionHandlerOptions
        //    {
        //        ExceptionHandler = async context =>
        //        {
        //            var user = context.User?.Identity as System.Security.Principal.WindowsIdentity ?? context.User?.Identity;
        //            var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
        //            var exception = errorFeature.Error;
        //            var problemDetails = new ProblemDetails {Instance = $"urn:myorganization:error:{Guid.NewGuid()}"};

        //            if (exception is BadHttpRequestException badHttpRequestException)
        //            {
        //                problemDetails.Title = "Invalid request";

        //                problemDetails.Status =
        //                    (int) typeof(BadHttpRequestException)
        //                          .GetProperty("StatusCode", BindingFlags.NonPublic | BindingFlags.Instance)
        //                          .GetValue(badHttpRequestException);

        //                problemDetails.Detail = badHttpRequestException.Message;
        //            }
        //            else
        //            {
        //                problemDetails.Title = "An unexpected error occurred!";
        //                problemDetails.Status = 500;
        //                problemDetails.Detail = exception.Demystify().ToString();
        //            }

        //            var nl = Environment.NewLine;
        //            var msg = $"ERROR: {problemDetails.Title}{nl}User:{nl}{user?.Name}{nl}StatusCode:{nl}{problemDetails.Status}{nl}";
        //            await logger.LogErrorAsync(msg, LoggerConstants.TraceLevelVerbose, exception.Demystify(), 0, DateTime.Now);

        //            //context.Response.StatusCode = problemDetails.Status.Value;

        //            // produce some response for the caller
        //            //context.Response.WriteJson(problemDetails, "application/problem+json");
        //        },
        //        ExceptionHandlingPath = new PathString("/Home/Error")
        //    };
        //}
    }





}
