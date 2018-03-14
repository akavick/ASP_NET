using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;
using Syncfusion.EJ2.Grids;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public List<Record> Records;

        Grid Grid;


        public void OnGet()
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

            Records = Enumerable
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

            //Grid = Component.;
            //Grid.DataSource = new List<Record>();
            //var bytes = Encoding.UTF8.GetBytes("WOOOOOOOOOOOHOOOOOOOOOOOOOO!");
            //PageContext.HttpContext.Response.Body.Write(bytes, 0, bytes.Length);
            //PageContext.HttpContext.Response.Body.Flush();
        }
    }
}
