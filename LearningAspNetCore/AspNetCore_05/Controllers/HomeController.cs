using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore_05.Models;

using Microsoft.AspNetCore.Http;





namespace AspNetCore_05.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ////ViewBag.User = HttpContext.User.Identity.Name;

            //var table = Request.Headers.Aggregate("", (current, header) => current + $"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");

            //Response.WriteAsync(string.Format("<table>{0}</table>", table));

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
