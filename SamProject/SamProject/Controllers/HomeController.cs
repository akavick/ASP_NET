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





        private async Task SetFormData(Application app)
        {
            await Task.Run(() =>
            {
                ViewBag.StartDate = app.BeginDate.AddDays(-1);
                ViewBag.EndDate = app.EndDate.AddDays(1);
                ViewBag.ColumnsDataSource = Repository.GetColumnsData(app);
                ViewBag.LineDataSource = Repository.GetLineData(app);

                ViewBag.SpecialtiesDataSource = Enum.GetValues(typeof(Specialty))
                                                    .Cast<Specialty>()
                                                    .Select(s => s.String())
                                                    .ToArray();

                ViewBag.QualificationsDataSource = Enum.GetValues(typeof(Qualification))
                                                       .Cast<Qualification>()
                                                       .Select(s => s.String())
                                                       .ToArray();

                ViewBag.ApplicationsDataSource = Repository.Applications;
                ViewBag.RatesDataSource = Repository.Rates;
                ViewBag.ProjectsDataSource = Repository.Projects;
                ViewBag.CandidatesDataSource = Repository.People;
            });
        }





        private async Task SetGridData(Application app)
        {
            await Task.Run(() => ViewBag.GridDataSource = Repository.Applications);
            await Task.Run(() => ViewBag.CommentsGridDataSource = Repository.Comments);

        }





        public async Task<IActionResult> Form(int appId)
        {
            var app = Repository.Applications.First(a => a.Id == (appId == 0 ? 1 : appId));

            await SetFormData(app);
            await SetGridData(app);

            return View(app);
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
            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

            return View(errorViewModel);
        }
    }





}
