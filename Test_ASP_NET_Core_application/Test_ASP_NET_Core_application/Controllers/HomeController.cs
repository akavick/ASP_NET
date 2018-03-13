using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test_ASP_NET_Core_application.Models;

namespace Test_ASP_NET_Core_application.Controllers
{
    public class HomeController : Controller
    {

        //public string Index()
        //{
        //    return "<div>Hello</div>";
        //}

        public IActionResult Index()
        {
            ViewData["Title"] = "Hello!";
            ViewBag.WooHoo = "WooHoo!";
            return View("TestView");
        }

        [HttpGet]
        public IActionResult RsvpForm() => View();

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (!ModelState.IsValid)
                return View();
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
        }

        public IActionResult ShowResponses() => View("ResponsesList", Repository.Responses);

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
