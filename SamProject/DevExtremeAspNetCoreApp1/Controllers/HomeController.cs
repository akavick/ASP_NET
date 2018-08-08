using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeAspNetCoreApp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var barDataSource = new List<object>
            {
                new {State = "Germany", Young = 6.7, Middle = 28.6, Older = 5.1},
                new {State = "Japan", Young = 9.6, Middle = 43.4, Older = 9},
                new {State = "Russia", Young = 13.5, Middle = 49, Older = 5.8},
                new {State = "USA", Young = 30, Middle = 90.3, Older = 14.5}
            };

            ViewBag.BarDataSource = barDataSource;


            return View();
        }

    }
}
