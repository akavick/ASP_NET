using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace Permissions.Controllers
{

    public class WorkController : Controller
    {
        public IActionResult FirstPage()
        {
            return View();
        }



        public IActionResult SecondPage()
        {
            return View();
        }



        public IActionResult ThirdPage()
        {
            return View();
        }
    }

}