using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HowToBeatNPM_1.Models;

namespace HowToBeatNPM_1.Controllers
{
    public class Record
    {
        public int OrderId { get; set; }
        public List<Customer> Customers { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipCountry { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var r = new Random();

            var letters = Enumerable
                          .Range(Convert.ToInt32('a'), 26)
                          .Select(Convert.ToChar)
                          .ToList();

            var customers = Enumerable
                            .Range(1, 20)
                            .Select(i => new Customer
                            {
                                Id = i
                                ,
                                DateOfBirth = DateTime.Now
                                                      .AddYears(-r.Next(18, 61))
                                                      .AddMonths(-r.Next(13))
                                                      .AddDays(-r.Next(32))
                                ,
                                FirstName = letters.OrderBy(l => r.Next())
                                                   .Take(r.Next(3, 11))
                                                   .Aggregate(new StringBuilder(), (sb, c) => sb.Append(c))
                                                   .ToString()
                                ,
                                LastName = letters.OrderBy(l => r.Next())
                                                  .Take(r.Next(3, 11))
                                                  .Aggregate(new StringBuilder(), (sb, c) => sb.Append(c))
                                                  .ToString()
                            })
                            .ToList();

            var orders = Enumerable
                        .Range(1, 100)
                        .Select(i =>
                        {
                            var od = DateTime.Now
                                             .AddYears(r.Next(11) - 5)
                                             .AddMonths(r.Next(13))
                                             .AddDays(r.Next(32));

                            return new Record
                            {
                                OrderId = i
                                ,
                                Freight = r.NextDouble() * 1000.0
                                ,
                                ShipCountry = $"Country_{r.Next(1, 11)}"
                                ,
                                OrderDate = od
                                ,
                                ShippedDate = od.AddYears(-r.Next(3))
                                                .AddMonths(-r.Next(13))
                                                .AddDays(-r.Next(32))
                                ,
                                Customers = customers.OrderBy(c => r.Next())
                                                     .Take(r.Next(1, customers.Count))
                                                     .ToList()
                            };
                        })
                        .ToList();

            ViewBag.datasource = orders;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
