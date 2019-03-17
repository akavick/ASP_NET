﻿using Microsoft.AspNetCore.Mvc;
using SamAppDemo.Managers;
using SamAppRepository.Models;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SamAppDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManager _manager;



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
        public async Task<IActionResult> Form(string number)
        {
            var user = User;

            var app =
                (await _manager.GetApplicationsAsync())
                .FirstOrDefault(a => a.Number == number);

            if (app is null)
            {
                app = await _manager.GetNewApplication();
            }
            else
            {
                ViewBag.CommentsGridDataSource = await _manager.GetCommentsAsync();
            }

            await SetChartData(app);
            await SetFormData();

            return View(app);
        }



        [HttpPost]
        public async Task<IActionResult> Form(string number, DateTime beginDate, DateTime endDate, RateValueType rate)
        {
            var year = DateTime.Now.Year;

            var minDate = new DateTime(year, 1, 1);
            var maxDate = new DateTime(year, 12, 31);

            if (beginDate < minDate)
            {
                beginDate = minDate;
            }

            if (endDate < minDate)
            {
                endDate = minDate;
            }

            if (endDate > maxDate)
            {
                endDate = maxDate;
            }

            if (beginDate > endDate)
            {
                beginDate = endDate;
            }

            var app =
                (await _manager.GetApplicationsAsync())
                .FirstOrDefault(a => a.Number == number);

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

            return View(app);
        }



        //public async Task<IActionResult> ChartDataSource([FromBody]DataManagerRequest dm, int id)
        //{
        //    return await GridDataSource(dm, id, new RsApplication());
        //}



        public async Task<IActionResult> ProjectInfo(int projectId)
        {
            var project =
                (await _manager.GetProjectsAsync())
                .SingleOrDefault(p => p.Id == projectId) ?? new Project();


            return Json(project);
        }



        //public async Task<IActionResult> ChartDataAjax(int id)
        //{
        //    var app =
        //        (await _manager.GetApplicationsAsync())
        //        .FirstOrDefault(a => a.Id == id) ?? await _manager.GetNewApplication();
        //    var columns = await _manager.GetColumnsDataAsync(app);
        //    var line = await _manager.GetLineDataAsync(app);
        //    return Json(new { columns, line });
        //}



        public async Task<IActionResult> CrossingGridDataSource([FromBody]DataManagerRequest dm, int id, DateTime beginDate, DateTime endDate, RateValueType rate)
        {
            return await GridDataSource<RsApplication>(dm, id, beginDate, endDate, rate);
        }



        public async Task<IActionResult> AmRateGridDataSource([FromBody]DataManagerRequest dm, int id, DateTime beginDate, DateTime endDate, RateValueType rate)
        {
            return await GridDataSource<AmRateApplication>(dm, id, beginDate, endDate, rate);
        }



        public async Task<IActionResult> AmOzsGridDataSource([FromBody]DataManagerRequest dm, int id, DateTime beginDate, DateTime endDate, RateValueType rate)
        {
            return await GridDataSource<AmOzsApplication>(dm, id, beginDate, endDate, rate);
        }



        private async Task<IActionResult> GridDataSource<T>([FromBody] DataManagerRequest dm, int id, DateTime beginDate, DateTime endDate, RateValueType rate)
            where T : IApplication
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

            IEnumerable dataSource = null;

            if (typeof(T) == typeof(RsApplication))
            {
                dataSource = await _manager.GetCrossingGridDataAsync(app);

                foreach (RsApplication application in dataSource)
                {
                    application.RsApplicationLink = $"<a href='{Url.RouteUrl(new { controller = "Home", action = "Form", number = application.Number })}' target='_blank'>{application.Number}</a>";
                }
            }
            else if (typeof(T) == typeof(AmRateApplication))
            {
                dataSource = await _manager.GetAmRateApplicationsAsync(app);
            }
            else if (typeof(T) == typeof(AmOzsApplication))
            {
                dataSource = await _manager.GetAmOzsApplicationsAsync(app);
            }

            var operation = new DataOperations();

            if (dm.Search != null && dm.Search.Count > 0)
            {
                dataSource = operation.PerformSearching(dataSource, dm.Search);  //Search
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                dataSource = operation.PerformSorting(dataSource, dm.Sorted);
            }

            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                const string @operator = "contains";

                foreach (var whereFilter in dm.Where)
                {
                    whereFilter.Operator = @operator;

                    foreach (var whereFilterPredicate in whereFilter.predicates)
                    {
                        whereFilterPredicate.Operator = @operator;
                    }
                }

                dataSource = operation.PerformFiltering(dataSource, dm.Where, @operator);
            }

            var count = dataSource.OfType<object>().Count();

            if (dm.Skip != 0)
            {
                dataSource = operation.PerformSkip(dataSource, dm.Skip);   //Paging
            }

            if (dm.Take != 0)
            {
                dataSource = operation.PerformTake(dataSource, dm.Take);
            }

            return dm.RequiresCounts
                ? Json(new { result = dataSource, count = count })
                : Json(dataSource);
        }



        #region essential

        public async Task<IActionResult> Index()
        {
            await Task.CompletedTask;

            return View();
        }



        public async Task<IActionResult> Privacy()
        {
            await Task.CompletedTask;

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            await Task.CompletedTask;

            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

            return View(errorViewModel);

        }

        #endregion
    }

}
