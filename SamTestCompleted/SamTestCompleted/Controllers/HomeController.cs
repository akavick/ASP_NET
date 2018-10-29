using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using SamLogger.Interfaces;

using SamTestCompleted.Models;
using SamTestCompleted.ViewModels;





namespace SamTestCompleted.Controllers
{

    public class HomeController : Controller
    {
        private readonly ISamLogProcessor _logger;



        public HomeController(ISamLogProcessor logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var statusCode = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error 
                //is HttpException httpEx ?
                //httpEx.StatusCode : (HttpStatusCode)Response.StatusCode
                ;



            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }



        [Authorize(Policy = "TestPolicy1")]
        public IActionResult BuggedPage()
        {
            return View();
        }



        [Authorize(Policy = "TestPolicy1")]
        [Authorize(Policy = "TestPolicy2")]
        public IActionResult BuggedMethod()
        {
            var y = 0;
            var x = 1;
            var result = x / y;

            return Content($"BuggedMethod: {result}");
        }



        public IActionResult BuggedMethod2()
        {
            var result = Task.Run(async () =>
            {
                await Task.Yield();

                var sum = Enumerable
                          .Range(1, 10)
                          .Select(async i =>
                          {
                              return await Task.Run(async () =>
                              {
                                  return await Task.Run(async () =>
                                  {
                                      await Task.Yield();

                                      if (i == 3)
                                      {
                                          throw new AggregateException
                                              (
                                               "agg1",
                                               new AggregateException
                                                   (
                                                    "agg2",
                                                    new Exception("ex3"),
                                                    new Exception("ex3")
                                                   ),
                                               new AggregateException
                                                   (
                                                    "agg2",
                                                    new Exception("ex3"),
                                                    new Exception("ex3")
                                                   )
                                              );
                                      }

                                      return i * i;
                                  });
                              });
                          })
                          .Sum(task => task.Result);

                return sum;
            }).Result;

            return Content(result.ToString());
        }



        public IActionResult UiError([FromBody] UiError error)
        {
            var nl = Environment.NewLine;
            var msg = $"UI ERROR from url: {error.Url}{nl}User:{nl}{error.User}{nl}Message:{nl}{error.Message}{nl}Stack:{nl}{error.Stack}{nl}";

            _logger.LogWarning(msg);

            return Json(new {Result = "failed"});
        }
    }

}
