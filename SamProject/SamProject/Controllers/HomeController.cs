using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SamProject.Managers;
using SamProject.Models;





namespace SamProject.Controllers
{





    public class HomeController : Controller
    {
        private IManager _manager;





        public HomeController(IManager manager)
        {
            _manager = manager;
        }





        public async Task<IActionResult> Create(dynamic obj)
        {
            return await Task.Run(() => Ok());
        }





        private async Task SetChartData(Application app)
        {
            ViewBag.ColumnsDataSource = await _manager.GetColumnsDataAsync(app);
            ViewBag.LineDataSource = await _manager.GetLineDataAsync(app);
        }





        private async Task SetFormData()
        {
            ViewBag.SpecialtiesDataSource = Enum.GetValues(typeof(Specialty))
                                                .Cast<Specialty>()
                                                .Select(s => s.String())
                                                .ToArray();

            ViewBag.QualificationsDataSource = Enum.GetValues(typeof(Qualification))
                                                   .Cast<Qualification>()
                                                   .Select(s => s.String())
                                                   .ToArray();

            ViewBag.ApplicationsDataSource = await _manager.GetApplicationsAsync();
            ViewBag.RatesDataSource = await _manager.GetRatesAsync();
            ViewBag.ProjectsDataSource = await _manager.GetProjectsAsync();
            ViewBag.CandidatesDataSource = await _manager.GetPeopleAsync();
        }





        private async Task SetGridData(Application app)
        {
            ViewBag.GridDataSource = await _manager.GetApplicationsAsync();
            ViewBag.CommentsGridDataSource = await _manager.GetCommentsAsync();
        }





        [HttpGet]
        public async Task<IActionResult> Form()
        {
            ViewBag.ApplicationsDataSource = await _manager.GetApplicationsAsync();

            await SetFormData();

            return View(null);
        }





        [HttpPost]
        public async Task<IActionResult> Form(int id)
        {
            var app = 
                (await _manager.GetApplicationsAsync())
                .FirstOrDefault(a => a.Id == id);

            await SetChartData(app);
            await SetFormData();
            await SetGridData(app);

            return View(app);
        }





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





}
