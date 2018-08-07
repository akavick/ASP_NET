using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamProjectTelerik.Models;





namespace SamProjectTelerik.Controllers
{
    public class ChartData
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double[] DataSource { get; set; }
    }






    public class HomeController : Controller
    {
        public IActionResult Form()
        {
            const int datesCount = 10;
            var date = new DateTime(2018, 7, 1);
            var dates = new string[datesCount];

            for (var i = 0; i < datesCount; i++)
            {
                dates[i] = date.AddDays(i).ToString("dd MMM");
            }

            var columnChart = new[]
            {
                new ChartData
                {
                    Name = "project #1",
                    Color = "green",
                    DataSource = new double[datesCount]{0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.0, 0.0}
                },
                new ChartData
                {
                    Name = "project #1 Internal",
                    Color = "gray",
                    DataSource = new double[datesCount]{0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.25, 0.25}
                },
                new ChartData
                {
                    Name = "project #2",
                    Color = "yellow",
                    DataSource = new double[datesCount]{0.0, 0.25, 0.25, 0.25, 0.25, 0.0, 0.0, 0.0, 0.0, 0.0}
                },
                new ChartData
                {
                    Name = "project #3",
                    Color = "orange",
                    DataSource = new double[datesCount]{0.0, 0.0, 0.0, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25}
                },
                new ChartData
                {
                    Name = "project #4",
                    Color = "red",
                    DataSource = new double[datesCount]{ 0.0, 0.0, 0.0, 0.0, 0.25, 0.0, 0.0, 0.0, 0.0, 0.0}
                },
            };


            var lineChart = new[]
            {
                new ChartData
                {
                    Name = "",
                    Color = "black",
                    DataSource = new double[datesCount]{1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 0.5}
                }
            };


            var areaChart = new[]
            {
                new ChartData
                {
                    Name = "",
                    Color = "gray",
                    DataSource = new double[datesCount]{1.0, 1.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 0.0}
                },
            };


            ViewBag.Dates = dates;
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
