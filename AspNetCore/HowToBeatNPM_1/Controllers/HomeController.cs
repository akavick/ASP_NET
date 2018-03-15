using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HowToBeatNPM_1.Classes;
using Microsoft.AspNetCore.Mvc;
using HowToBeatNPM_1.Models;
using HowToBeatNPM_1.Repositories;

namespace HowToBeatNPM_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.datasource = Repository.Records;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
