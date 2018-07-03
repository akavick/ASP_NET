using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Shop01.MobileDbContext;
using Shop01.Models;





namespace Shop01.Controllers
{

    public class HomeController : Controller
    {
        private MobileContext _db;





        public HomeController(MobileContext context)
        {
            _db = context;
        }





        public IActionResult Index()
        {
            return View(_db.Phones.ToList());
        }





        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.PhoneId = id;

            return View();
        }





        [HttpPost]
        public string Buy(Order order)
        {
            _db.Orders.Add(order);

            // сохраняем в бд все изменения
            _db.SaveChanges();

            return "Спасибо, " + order.User + ", за покупку!";
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }

}
