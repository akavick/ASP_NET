﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SamProject.Models;
using SamProject.Repositories;





namespace SamProject.Managers
{

    public class Manager : IManager
    {
        private readonly IRepository _repository;
        private List<ChartData<DateTime>> _columnChartData;
        private List<ChartData<double>> _lineChartData;





        public Manager(IRepository repository)
        {
            _repository = repository;
        }





        private bool AreApplicationsCrossing(Application app1, Application app2)
        {
            bool LeftCross()
            {
                return true;
            }



            return app1.Id == app2.Id
                || app1.BeginDate >= app2.BeginDate && app1.EndDate <= app2.EndDate
                || app2.BeginDate >= app1.BeginDate && app2.EndDate <= app1.EndDate
                || app2.EndDate >= app1.BeginDate && app2.EndDate <= app1.EndDate
                || app1.EndDate >= app2.BeginDate && app1.EndDate <= app2.EndDate
                || app2.BeginDate <= app1.EndDate && app2.BeginDate >= app1.BeginDate
                || app1.BeginDate <= app2.EndDate && app1.BeginDate >= app2.BeginDate;
        }





        public async Task<IEnumerable<ChartData<DateTime>>> GetColumnsDataAsync(Application application)
        {
            return await Task.Run(() =>
            {
                var colors = new[] { "green", "gray", "lightblue", "orange", "red", };

                var columnChart =
                    _repository.Applications.Where(app => app.Id == application.Id
                                                       || app.BeginDate >= application.BeginDate && app.EndDate <= application.EndDate
                                                       || application.BeginDate >= app.BeginDate && application.EndDate <= app.EndDate
                                                       || application.EndDate >= app.BeginDate && application.EndDate <= app.EndDate
                                                       || app.EndDate >= application.BeginDate && app.EndDate <= application.EndDate
                                                       || application.BeginDate <= app.EndDate && application.BeginDate >= app.BeginDate
                                                       || app.BeginDate <= application.EndDate && app.BeginDate >= application.BeginDate)
                               .GroupBy(app => app.Project)
                               .Select((appGroup, i) =>
                               {
                                   var source =
                                       appGroup.SelectMany(innerApp =>
                                       {
                                           var currentDate = innerApp.BeginDate;
                                           var dates = new List<DateTime> { currentDate };

                                           while (currentDate != innerApp.EndDate)
                                           {
                                               currentDate = currentDate.AddDays(1);
                                               dates.Add(currentDate);
                                           }

                                           var data =
                                           dates.Select(d => new ChartPoint<DateTime> { X = d, Y = (double)innerApp.Rate })
                                                .ToArray();

                                           return data;
                                       })
                                               .ToArray();

                                   var chartData = new ChartData<DateTime> { Name = appGroup.Key.Name, Color = colors[i], DataSource = source };

                                   return chartData;
                               })
                               .ToList();

                _columnChartData = columnChart;

                return columnChart;
            });
        }





        public async Task<IEnumerable<ChartData<double>>> GetLineDataAsync(Application application)
        {
            if (_columnChartData is null)
            {
                await GetColumnsDataAsync(application); //todo return
            }

            return await Task.Run(() =>
            {
                var linedata =
                    _columnChartData.SelectMany(cd => cd.DataSource)
                                    .GroupBy(ds => ds.X)
                                    .Select((dsGroup, i) => new ChartPoint<double> { X = i, Y = dsGroup.Sum(ds => ds.Y) })
                                    .ToArray();

                //if (application.Id == 1)
                //{
                //    linedata.Where(cp => cp.X > 90 && cp.X < 101)
                //            .ToList()
                //            .ForEach(cp => cp.Y -= 0.25);

                //    linedata.Where(cp => cp.X > 140 && cp.X < 151)
                //            .ToList()
                //            .ForEach(cp => cp.Y -= 0.5);

                //    linedata.Where(cp => cp.X > 30 && cp.X < 51)
                //            .ToList()
                //            .ForEach(cp => cp.Y = 0.0);

                //    linedata.Where(cp => cp.X > 190 && cp.X < 201)
                //            .ToList()
                //            .ForEach(cp => cp.Y = 0.0);

                //    linedata.Where(cp => cp.X > 250 && cp.X < 271)
                //            .ToList()
                //            .ForEach(cp => cp.Y = 0.0);

                //    linedata.Where(cp => cp.X > 330)
                //            .ToList()
                //            .ForEach(cp => cp.Y += 0.25);
                //}


                var lineChart = new List<ChartData<double>> { new ChartData<double> { Name = "", Color = "black", DataSource = linedata }, };

                _lineChartData = lineChart;

                return lineChart;
            });
        }





        public async Task<IEnumerable<Application>> GetCrossingGridDataAsync(Application app)
        {
            return await Task.Run(() => _repository.Applications.Where(a => 1 == 1).ToArray());
        }





        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await Task.Run(() => _repository.Comments);
        }





        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await Task.Run(() => _repository.People);
        }





        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await Task.Run(() => _repository.Clients);
        }





        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await Task.Run(() => _repository.Projects);
        }





        public async Task<IEnumerable<decimal>> GetRatesAsync()
        {
            return await Task.Run(() => _repository.Rates);
        }





        public async Task<IEnumerable<Application>> GetApplicationsAsync()
        {
            return await Task.Run(() => _repository.Applications);
        }

    }

}
