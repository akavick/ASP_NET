using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamProject.Models;





namespace SamProject.Controllers
{





    public class ChartData
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public object[] DataSource { get; set; }
    }






    public class HomeController : Controller
    {
        public IActionResult Form()
        {
            var date = new DateTime(2018, 7, 1);


            var columnChart = new[]
            {
                new ChartData
                {
                    Name = "base",
                    Color = "black",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(0), y = 0.0},
                        new {x = date.AddDays(1), y = 0.0},
                        new {x = date.AddDays(2), y = 0.0},
                        new {x = date.AddDays(3), y = 0.0},
                        new {x = date.AddDays(4), y = 0.0},
                        new {x = date.AddDays(5), y = 0.0},
                        new {x = date.AddDays(6), y = 0.0},
                        new {x = date.AddDays(7), y = 0.0},
                        new {x = date.AddDays(8), y = 0.0},
                        new {x = date.AddDays(9), y = 0.0},
                    }
                },
                new ChartData
                {
                    Name = "project #1",
                    Color = "green",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(0), y = 0.5},
                        new {x = date.AddDays(1), y = 0.5},
                        new {x = date.AddDays(2), y = 0.5},
                        new {x = date.AddDays(3), y = 0.5},
                        new {x = date.AddDays(4), y = 0.5},
                        new {x = date.AddDays(5), y = 0.5},
                        new {x = date.AddDays(6), y = 0.5},
                        new {x = date.AddDays(7), y = 0.5},
                    }
                },
                new ChartData
                {
                    Name = "project #1 Internal",
                    Color = "gray",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(8), y = 0.25},
                        new {x = date.AddDays(9), y = 0.25},
                    }
                },
                new ChartData
                {
                    Name = "project #2",
                    Color = "yellow",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(1), y = 0.25},
                        new {x = date.AddDays(2), y = 0.25},
                        new {x = date.AddDays(3), y = 0.25},
                        new {x = date.AddDays(4), y = 0.25},
                    }
                },
                new ChartData
                {
                    Name = "project #3",
                    Color = "orange",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(3), y = 0.25},
                        new {x = date.AddDays(4), y = 0.25},
                        new {x = date.AddDays(5), y = 0.25},
                        new {x = date.AddDays(6), y = 0.25},
                        new {x = date.AddDays(7), y = 0.25},
                        new {x = date.AddDays(8), y = 0.25},
                        new {x = date.AddDays(9), y = 0.25},
                    }
                },
                new ChartData
                {
                    Name = "project #4",
                    Color = "red",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(4), y = 0.25},
                    }
                },
            };


            var lineChart = new[]
            {
                new ChartData
                {
                    Name = "",
                    Color = "black",
                    DataSource = new object[]
                    {
                        new {x = 0.0, y = 1.0},
                        new {x = 1.0, y = 1.0},
                        new {x = 2.0, y = 1.0},
                        new {x = 3.0, y = 1.0},
                        new {x = 4.0, y = 1.0},
                        new {x = 5.0, y = 1.0},
                        new {x = 6.0, y = 1.0},
                        new {x = 7.0, y = 1.0},
                        new { x = 8.0, y = 1.0 },// переход вертикальный
                        new {x = 8.0, y = 0.5},
                        new {x = 9.0, y = 0.5},
                        new {x = 10.0, y = 0.5},
                    }
                },
            };


            var areaChart = new[]
            {
                new ChartData
                {
                    Name = "",
                    Color = "gray",
                    DataSource = new object[]
                    {
                        new {x = 0.0, y = 1.0},
                        new {x = 1.0, y = 1.0},
                        new {x = 2.0, y = 1.0},
                        new {x = 3.0, y = 1.0},
                    }
                },
                new ChartData
                {
                    Name = "",
                    Color = "gray",
                    DataSource = new object[]
                    {
                        new {x = 7.0, y = 1.0},
                        new {x = 8.0, y = 1.0},
                    }
                },
            };


            ViewBag.ColumnsDataSource = columnChart;
            ViewBag.LineDataSource = lineChart;
            ViewBag.AreaDataSource = areaChart;


            return View();
        }





        public IActionResult Grid()
        {
            return View();
        }





        public IActionResult Index()
        {
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
