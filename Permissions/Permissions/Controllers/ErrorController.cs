using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Permissions.Models;
using Permissions.ViewModels;



namespace Permissions.Controllers
{

    public class ErrorController : Controller
    {
        private IHostingEnvironment _env;



        public ErrorController(IHostingEnvironment env)
        {
            _env = env;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }



        public IActionResult UiError([FromBody] UiError error)
        {
            return Ok();
        }
    }

}