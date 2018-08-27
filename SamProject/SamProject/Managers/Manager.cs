using System;
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





        public Manager(IRepository repository)
        {
            _repository = repository;
        }





        private bool AreApplicationsCrossing(Application app1, Application app2)
        {
            //bool LeftCross()
            //{
            //    return true;
            //}



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
                    _repository.Applications
                               .Where(app => app.Id == application.Id
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
                                               dates.Select(d => new ChartPoint<DateTime>
                                               {
                                                   X = d,
                                                   Y = (double)innerApp.Rate
                                               })
                                                    .ToArray();

                                           return data;
                                       })
                                       .ToList();

                                   var chartData = new ChartData<DateTime>
                                   {
                                       Name = appGroup.Key.Name,
                                       Color = colors[i],
                                       DataSource = source
                                   };

                                   return chartData;
                               })
                               .ToList();

                return columnChart;
            });
        }





        public async Task<IEnumerable<ChartData<DateTime>>> GetLineDataAsync(Application application)
        {
            //var columnChartData = 
            //    (await GetColumnsDataAsync(application))
            //    .SelectMany(cd => cd.DataSource)
            //    .GroupBy(ds => ds.X)
            //    .Select(dsGroup => new ChartPoint<DateTime>
            //    {
            //        X = dsGroup.Key.AddHours(-12),
            //        Y = dsGroup.Sum(ds => ds.Y)
            //    })
            //    .ToList();

            //if (application.EndDate.Date > columnChartData.Last().X.Date)
            //{
            //    columnChartData.Add(new ChartPoint<DateTime>
            //    {
            //        X = application.EndDate.Date.AddHours(12),
            //        Y = columnChartData.Last().Y
            //    });
            //}

            var linedata =
                (await GetAmRateApplicationsAsync())
                .SelectMany(aa =>
                {
                    var currentDate = aa.BeginDate;
                    var dates = new List<DateTime> { currentDate };
                
                    while (currentDate != aa.EndDate)
                    {
                        currentDate = currentDate.AddDays(1);
                        dates.Add(currentDate);
                    }
                
                    var data =
                        dates.Select(d => new ChartPoint<DateTime>
                        {
                            X = d.AddHours(-12),
                            Y = (double)aa.Rate
                        })
                        .ToArray();
                
                    return data;
                })
                .OrderBy(cp => cp.X)
                .ToList();

            (await GetAmOzsApplicationsAsync())
            .SelectMany(aa =>
            {
                var currentDate = aa.BeginDate;
                var dates = new List<DateTime> { currentDate };

                while (currentDate != aa.EndDate)
                {
                    currentDate = currentDate.AddDays(1);
                    dates.Add(currentDate);
                }

                return dates;
            })
            .OrderBy(d => d)
            .ToList()
            .ForEach(d => linedata.Where(cp => cp.X == d.AddHours(-12))
                                  .ToList()
                                  .ForEach(cp => cp.Y = 0.0));

            if (application.EndDate.Date > linedata.Last().X.Date)
            {
                linedata.Add(new ChartPoint<DateTime>
                {
                    X = application.EndDate.Date.AddHours(12),
                    Y = linedata.Last().Y
                });
            }



            #region main app



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



            #endregion


            var lineChart = new List<ChartData<DateTime>>
            {
                new ChartData<DateTime>
                {
                    Name = "",
                    Color = "black",
                    DataSource = linedata
                },
            };

            return lineChart;

        }





        public async Task<IEnumerable<Application>> GetCrossingGridDataAsync(Application app)
        {
            return await Task.Run(() => _repository.Applications.Where(a => 1 == 1).ToArray()); //todo
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





        public async Task<IEnumerable<AmOzsApplication>> GetAmOzsApplicationsAsync()
        {
            return await Task.Run(() => _repository.AmApplications
                                                   .OfType<AmOzsApplication>()
                                                   .ToArray());
        }





        public async Task<IEnumerable<AmRateApplication>> GetAmRateApplicationsAsync()
        {
            return await Task.Run(() => _repository.AmApplications
                                                   .OfType<AmRateApplication>()
                                                   .ToArray());
        }

    }

}
