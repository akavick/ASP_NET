using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamProject.Models;
using SamProject.Repositories;





namespace SamProject.Controllers
{





    public class HomeController : Controller
    {
        public IActionResult Create(dynamic obj)
        {
            return Ok();
        }





        private async Task SetFormData()
        {
            await Task.Run(() =>
            {
                var date = new DateTime(2018, 7, 1);

                ViewBag.StartDate = date.AddDays(-1);
                ViewBag.EndDate = date.AddDays(10);
                ViewBag.ColumnsDataSource = Repository.GetColumnsData(date);
                ViewBag.LineDataSource = Repository.GetLineData(date);
                ViewBag.AreaDataSource = Repository.GetAreaData(date);

                ViewBag.RatesDataSource = Repository.Rates;
                ViewBag.ProjectsDataSource = Repository.Projects;
                ViewBag.CandidatesDataSource = Repository.People;
            });
        }





        private async Task SetGridData()
        {
            await Task.Run(() => ViewBag.GridDataSource = Repository.Applications());
        }





        public async Task<IActionResult> Form()
        {
            await SetFormData();
            await SetGridData();

            return View(Repository.Applications().First());
        }





        public async Task<IActionResult> FormSyncfusion()
        {
            await SetFormData();

            return View();
        }





        public async Task<IActionResult> Grid()
        {
            await SetGridData();

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
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }





}
