using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamProject.Models;

namespace SamProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            const double interval = 0.25;
            const double max = 2.0;
            var maxIntervals = (int)(max / interval);
            const string name = "date ";
            var chart = new List<List<StackedColumnChartData>>();
            var rand = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var column = new List<StackedColumnChartData>();
                var intervalsCount = rand.Next(maxIntervals + 1);

                for (int j = 1; j <= intervalsCount; j++)
                {
                    var val = new StackedColumnChartData {x = name + j, y = interval};
                    column.Add(val);
                }

                chart.Add(column);
            }


            //List<StackedColumnChartData> chartData1 = new List<StackedColumnChartData>
            //{
            //new StackedColumnChartData { x = "2014", y = 111.1 },
            //new StackedColumnChartData { x = "2015", y = 127.3 },
            //new StackedColumnChartData { x = "2016", y = 143.4 },
            //new StackedColumnChartData { x = "2017", y = 159.9 }
            //};

            //List<StackedColumnChartData> chartData2 = new List<StackedColumnChartData>
            //{
            //    new StackedColumnChartData { x= "2014", y= 76.9 },
            //    new StackedColumnChartData { x= "2015", y= 99.5 },
            //    new StackedColumnChartData { x= "2016", y= 121.7 },
            //    new StackedColumnChartData { x= "2017", y= 142.5 }
            //};

            //List<StackedColumnChartData> chartData3 = new List<StackedColumnChartData>
            //{
            //    new StackedColumnChartData { x= "2014", y= 66.1 },
            //    new StackedColumnChartData { x= "2015", y= 79.3 },
            //    new StackedColumnChartData { x= "2016", y= 91.3 },
            //    new StackedColumnChartData { x= "2017", y= 102.4 }
            //};

            //List<StackedColumnChartData> chartData4 = new List<StackedColumnChartData>
            //{
            //    new StackedColumnChartData { x= "2014", y= 34.1 },
            //    new StackedColumnChartData { x= "2015", y= 38.2 },
            //    new StackedColumnChartData { x= "2016", y= 44.0 },
            //    new StackedColumnChartData { x= "2017", y= 51.6 }
            //};

            ViewBag.dataSource = chart;

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



    public class StackedColumnChartData
    {
        public string x;
        public double y;
    }
}
