using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;
using Chart_01.Models;





namespace Chart_01.Controllers
{
    public class StackedColumnChartData
    {
        public string x;
        public double y;
    }





    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<StackedColumnChartData> chartData = new List<StackedColumnChartData>
            {
                new StackedColumnChartData { x= "2014", y= 111.1 },
                new StackedColumnChartData { x= "2015", y= 127.3 },
                new StackedColumnChartData { x= "2016", y= 143.4 },
                new StackedColumnChartData { x= "2017", y= 159.9 }
            };
            ViewBag.dataSource = chartData;
            List<StackedColumnChartData> chartData1 = new List<StackedColumnChartData>
            {
                new StackedColumnChartData { x= "2014", y= 76.9 },
                new StackedColumnChartData { x= "2015", y= 99.5 },
                new StackedColumnChartData { x= "2016", y= 121.7 },
                new StackedColumnChartData { x= "2017", y= 142.5 }
            };
            ViewBag.dataSource1 = chartData1;
            List<StackedColumnChartData> chartData2 = new List<StackedColumnChartData>
            {
                new StackedColumnChartData { x= "2014", y= 66.1 },
                new StackedColumnChartData { x= "2015", y= 79.3 },
                new StackedColumnChartData { x= "2016", y= 91.3 },
                new StackedColumnChartData { x= "2017", y= 102.4 }
            };
            ViewBag.dataSource2 = chartData2;
            List<StackedColumnChartData> chartData3 = new List<StackedColumnChartData>
            {
                new StackedColumnChartData { x= "2014", y= 34.1 },
                new StackedColumnChartData { x= "2015", y= 38.2 },
                new StackedColumnChartData { x= "2016", y= 44.0 },
                new StackedColumnChartData { x= "2017", y= 51.6 }
            };
            ViewBag.dataSource3 = chartData3;
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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }





}
