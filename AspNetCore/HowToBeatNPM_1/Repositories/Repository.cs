using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HowToBeatNPM_1.Classes;

namespace HowToBeatNPM_1.Repositories
{
    public static class Repository
    {
        public static List<Record> Records { get; }

        static Repository()
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
                          var sd = DateTime.Now
                                           .AddYears(r.Next(11) - 5)
                                           .AddMonths(r.Next(13))
                                           .AddDays(r.Next(32));

                          return new Record
                          {
                              OrderId = i + 1000
                              ,
                              Freight = r.NextDouble() * 1000.0
                              ,
                              ShipCountry = $"Country_{r.Next(1, 11)}"
                              ,
                              OrderDate = sd.AddYears(-r.Next(3))
                                            .AddMonths(-r.Next(13))
                                            .AddDays(-r.Next(32))
                              ,
                              ShippedDate = sd
                              ,
                              Customers = customers.OrderBy(c => r.Next())
                                                   .Take(r.Next(1, customers.Count))
                                                   .ToList()
                          };
                      })
                      .OrderBy(rec => r.Next())
                      .Select((rec, i) =>
                      {
                          rec.RecordId = i + 1;
                          return rec;
                      })
                      .ToList();
        }
    }
}
