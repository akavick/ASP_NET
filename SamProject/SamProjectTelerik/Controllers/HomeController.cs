using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Kendo.Mvc.UI;

using Microsoft.AspNetCore.Mvc;

using Repository.Models;

using SamProjectTelerik.Managers;





namespace SamProjectTelerik.Controllers
{




    public class HomeController : Controller
    {
        private IManager _manager;





        public HomeController(IManager manager)
        {
            _manager = manager;
        }





        private async Task SetChartData(RsApplication app)
        {
            ViewBag.ColumnsDataSource = await _manager.GetColumnsDataAsync(app);
            ViewBag.LineDataSource = await _manager.GetLineDataAsync(app);
        }





        private async Task SetFormData()
        {
            ViewBag.ApplicationsDataSource = await _manager.GetApplicationsAsync();
            ViewBag.RatesDataSource = await _manager.GetRatesAsync();
            ViewBag.ProjectsDataSource = await _manager.GetProjectsAsync();
            ViewBag.CandidatesDataSource = await _manager.GetPeopleAsync();
        }





        [HttpGet]
        public async Task<IActionResult> Form()
        {
            var app = await _manager.GetNewApplication();

            await SetChartData(app);
            await SetFormData();
            ViewBag.AmRateGridDataSource = await _manager.GetAmRateApplicationsAsync(app);

            return View(app);
        }





        [HttpPost]
        public async Task<IActionResult> Form(int id, DateTime beginDate, DateTime endDate, RateValueType rate)
        {
            var app =
                (await _manager.GetApplicationsAsync())
                .FirstOrDefault(a => a.Id == id);

            if (app is null)
            {
                app = await _manager.GetNewApplication();
                app.BeginDate = beginDate;
                app.EndDate = endDate;
                app.Rate = new Rate { Type = rate };
            }
            else
            {
                ViewBag.CommentsGridDataSource = await _manager.GetCommentsAsync();
            }

            await SetChartData(app);
            await SetFormData();

            ViewBag.AmRateGridDataSource = await _manager.GetAmRateApplicationsAsync(app);

            return View(app);
        }




        public async Task<IActionResult> ChartDataAjax(RsApplication app)
        {
            var columns = await _manager.GetColumnsDataAsync(app);
            var line = await _manager.GetLineDataAsync(app);


            return await Task.FromResult(Json(new { columns, line }));
        }




        //public async Task<IActionResult> ChartDataSource(/*[FromBody]DataManagerRequest dm, int id*/)
        //{
        //    return await GridDataSource(dm, id, new RsApplication());
        //}





        //public async Task<IActionResult> CrossingGridDataSource([FromBody]DataManagerRequest dm, int id, DateTime beginDate, DateTime endDate, RateValueType rate)
        //{
        //    return await GridDataSource(dm, id, beginDate, endDate, rate, new RsApplication());
        //}





        //public async Task<IActionResult> AmRateGridDataSource([FromBody]DataManagerRequest dm, int id, DateTime beginDate, DateTime endDate, RateValueType rate)
        //{
        //    return await GridDataSource(dm, id, beginDate, endDate, rate, new AmRateApplication());
        //}





        //public async Task<IActionResult> AmOzsGridDataSource([FromBody]DataManagerRequest dm, int id, DateTime beginDate, DateTime endDate, RateValueType rate)
        //{
        //    return await GridDataSource(dm, id, beginDate, endDate, rate, new AmOzsApplication());
        //}





        //private async Task<IActionResult> GridDataSource([FromBody] DataManagerRequest dm, int id, DateTime beginDate, DateTime endDate, RateValueType rate, object obj)
        //{
        //    var app =
        //        (await _manager.GetApplicationsAsync())
        //        .FirstOrDefault(a => a.Id == id);

        //    if (app is null)
        //    {
        //        app = await _manager.GetNewApplication();
        //        app.BeginDate = beginDate;
        //        app.EndDate = endDate;
        //        app.Rate = new Rate { Type = rate };
        //    }

        //    IEnumerable dataSource = null;

        //    switch (obj)
        //    {
        //        case RsApplication _:
        //            dataSource = await _manager.GetCrossingGridDataAsync(app);
        //            break;
        //        case AmRateApplication _:
        //            dataSource = await _manager.GetAmRateApplicationsAsync(app);
        //            break;
        //        case AmOzsApplication _:
        //            dataSource = await _manager.GetAmOzsApplicationsAsync(app);
        //            break;
        //    }

        //    var operation = new DataOperations();

        //    if (dm.Search != null && dm.Search.Count > 0)
        //    {
        //        dataSource = operation.PerformSearching(dataSource, dm.Search);  //Search
        //    }

        //    if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
        //    {
        //        dataSource = operation.PerformSorting(dataSource, dm.Sorted);
        //    }

        //    if (dm.Where != null && dm.Where.Count > 0) //Filtering
        //    {
        //        dataSource = operation.PerformFiltering(dataSource, dm.Where, dm.Where[0].Operator);
        //    }

        //    var count = dataSource.OfType<object>().Count();

        //    if (dm.Skip != 0)
        //    {
        //        dataSource = operation.PerformSkip(dataSource, dm.Skip);   //Paging
        //    }

        //    if (dm.Take != 0)
        //    {
        //        dataSource = operation.PerformTake(dataSource, dm.Take);
        //    }

        //    return dm.RequiresCounts
        //        ? Json(new { result = dataSource, count = count })
        //        : Json(dataSource);
        //}




        #region essential



        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }





        public async Task<IActionResult> Privacy()
        {
            return await Task.Run(() => View());
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return await Task.Run(() =>
            {
                var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

                return View(errorViewModel);
            });
        }



        #endregion
    }




    //public class HomeController : Controller
    //{
    //    public IActionResult Form()
    //    {
    //        const int datesCount = 10;
    //        var date = new DateTime(2018, 7, 1);
    //        //var dates = new string[datesCount];

    //        //for (var i = 0; i < datesCount; i++)
    //        //{
    //        //    dates[i] = date.AddDays(i).ToString("dd MMM");
    //        //}

    //        var dates = new DateTime[datesCount];

    //        for (var i = 0; i < datesCount; i++)
    //        {
    //            dates[i] = date.AddDays(i);
    //        }

    //        var columnChart = new[]
    //        {
    //            new ChartSeries<DateTime, decimal>
    //            {
    //                Name = "project #1",
    //                Color = "green",
    //                DataSource = new []
    //                {
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(0), Y = 0.5m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(1), Y = 0.5m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(2), Y = 0.5m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(3), Y = 0.5m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(4), Y = 0.5m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(5), Y = 0.5m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(6), Y = 0.5m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(7), Y = 0.5m},
    //                }
    //            },
    //            new ChartSeries<DateTime, decimal>
    //            {
    //                Name = "project #1 Internal",
    //                Color = "gray",
    //                DataSource = new []
    //                {
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(8), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(9), Y = 0.25m},
    //                }
    //            },
    //            new ChartSeries<DateTime, decimal>
    //            {
    //                Name = "project #2",
    //                Color = "yellow",
    //                DataSource = new []
    //                {
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(1), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(2), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(3), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(4), Y = 0.25m},
    //                }
    //            },
    //            new ChartSeries<DateTime, decimal>
    //            {
    //                Name = "project #3",
    //                Color = "orange",
    //                DataSource = new []
    //                {
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(3), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(4), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(5), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(6), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(7), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(8), Y = 0.25m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(9), Y = 0.25m},
    //                }
    //            },
    //            new ChartSeries<DateTime, decimal>
    //            {
    //                Name = "project #4",
    //                Color = "red",
    //                DataSource = new []
    //                {
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(4), Y = 0.25m},
    //                }
    //            },
    //        };


    //        var lineChart = new[]
    //        {
    //            new ChartSeries<DateTime, decimal>
    //            {
    //                Name = "",
    //                Color = "black",
    //                DataSource = new []
    //                {
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(0), Y = 1.0m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(1), Y = 1.0m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(2), Y = 1.0m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(3), Y = 1.0m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(4), Y = 1.0m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(5), Y = 1.0m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(6), Y = 1.0m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(7), Y = 1.0m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(8), Y = 0.5m},
    //                    new ChartPoint<DateTime, decimal>{X = date.AddDays(9), Y = 0.5m},
    //                }
    //            }
    //        };



    //        ViewBag.Dates = dates;
    //        ViewBag.ColumnsDataSource = columnChart;
    //        ViewBag.LineDataSource = lineChart;


    //        return View();
    //    }







    //    public IActionResult Index()
    //    {
    //        return View();
    //    }






    //    public IActionResult Privacy()
    //    {
    //        return View();
    //    }





    //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //    public IActionResult Error()
    //    {
    //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //    }
    //}





}
