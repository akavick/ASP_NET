using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Repository.Models;
using Repository.Repositories;

using SamProjectTelerik.Models;





namespace SamProjectTelerik.Managers
{

    public class Manager : IManager
    {
        private readonly IRepository _repository;





        public Manager(IRepository repository)
        {
            _repository = repository;
        }




        public async Task<IEnumerable<ChartSeries<DateTime, decimal>>> GetColumnsDataAsync(RsApplication application)
        {
            return await Task.Run(() =>
            {
                var colors = new[] { "green", "darkred", "darkgray", "darkorange", "lightblue", "darkblue" };

                var columnChart =
                    _repository.ReservationSystemApplications
                               .Where(app => app.IntersectsWith(application))
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
                                                       dates.Select(d => new ChartPoint<DateTime, decimal>
                                                       {
                                                           X = d,
                                                           Y = innerApp.Rate.Value,
                                                       })
                                                       .ToArray();

                                                   return data;
                                               })
                                               .ToList();

                                   var chartSeries = new ChartSeries<DateTime, decimal>
                                   {
                                       Name = appGroup.Key.Name,
                                       Color = colors[i],
                                       DataSource = source,
                                       //SeriesType = Syncfusion.EJ2.Charts.ChartSeriesType.StackingColumn
                                   };

                                   return chartSeries;
                               })
                               .ToList();

                return columnChart;
            });
        }





        //public async Task<IEnumerable<ChartSeries<DateTime, decimal>>> GetColumnsDataAsync(RsApplication application)
        //{
        //    return await Task.Run(() =>
        //    {
        //        var colors = new[] { "green", "darkred", "darkgray", "darkorange", "lightblue", "darkblue" };

        //        var columnChart =
        //            _repository.ReservationSystemApplications
        //                       .Where(app => app.IntersectsWith(application))
        //                       .GroupBy(app => app.Project)
        //                       .Select((appGroup, i) =>
        //                       {
        //                           var source =
        //                               appGroup.SelectMany(innerApp =>
        //                                       {
        //                                           var currentDate = innerApp.BeginDate;
        //                                           var dates = new List<DateTime> { currentDate };

        //                                           while (currentDate != innerApp.EndDate)
        //                                           {
        //                                               currentDate = currentDate.AddDays(1);
        //                                               dates.Add(currentDate);
        //                                           }

        //                                           var data =
        //                                               dates.Select(d => new ChartPoint<DateTime, decimal>
        //                                               {
        //                                                   X = d,
        //                                                   Y = innerApp.Rate.Value,
        //                                               })
        //                                               .ToArray();

        //                                           return data;
        //                                       })
        //                                       .GroupBy(cp => cp.X)
        //                                       .Select(cpg =>
        //                                       {
        //                                           var cp = cpg.First();
        //                                           cp.Y = cpg.Sum(item => item.Y);
        //                                           return cp;
        //                                       })
        //                                       .ToList();

        //                           var chartSeries = new ChartSeries<DateTime, decimal>
        //                           {
        //                               Name = appGroup.Key.Name,
        //                               Color = colors[i],
        //                               DataSource = source,
        //                               //SeriesType = Syncfusion.EJ2.Charts.ChartSeriesType.StackingColumn
        //                           };

        //                           return chartSeries;
        //                       })
        //                       .ToList();

        //        return columnChart;
        //    });
        //}





        //public async Task<IEnumerable<ChartSeries<DateTime, decimal>>> GetColumnsDataAsync(RsApplication application)
        //{
        //    return await Task.Run(() =>
        //    {
        //        var colors = new[] { "green", "darkred", "darkgray", "darkorange", "lightblue", "darkblue" };

        //        var projectsColors =
        //            _repository.Projects
        //                       .Select((p, i) => new
        //                       {
        //                           Project = p,
        //                           Color = colors[i]
        //                       })
        //                       .ToDictionary(pc => pc.Project, pc => pc.Color);

        //        var columnChart =
        //            _repository.ReservationSystemApplications
        //                       .Where(app => app.IntersectsWith(application))
        //                       .OrderBy(app => app.BeginDate)
        //                       .ThenBy(app => app.EndDate)
        //                       .Select(app =>
        //                       {
        //                           var currentDate = app.BeginDate;
        //                           var dates = new List<DateTime> { currentDate };

        //                           while (currentDate != app.EndDate)
        //                           {
        //                               currentDate = currentDate.AddDays(1);
        //                               dates.Add(currentDate);
        //                           }

        //                           var data =
        //                               dates.Select(d => new ChartPoint<DateTime, decimal>
        //                                    {
        //                                        X = d,
        //                                        Y = app.Rate.Value,
        //                                        //RsApplicationId = innerApp.Id,
        //                                        //RsApplicationNumber = innerApp.Number
        //                                    })
        //                                    .ToArray();

        //                           var chartSeries = new ChartSeries<DateTime, decimal>
        //                           {
        //                               Name = app.Project.Name,
        //                               Color = projectsColors[app.Project],
        //                               DataSource = data,
        //                               //SeriesType = Syncfusion.EJ2.Charts.ChartSeriesType.StackingColumn
        //                           };

        //                           return chartSeries;
        //                       })
        //                       .ToList();

        //        return columnChart;
        //    });
        //}





        public async Task<IEnumerable<ChartSeries<DateTime, decimal>>> GetLineDataAsync(RsApplication application)
        {
            //var columnChartSeries =
            //    (await GetColumnsDataAsync(application))
            //    .SelectMany(cd => cd.DataSource)
            //    .GroupBy(ds => ds.X)
            //    .Select(dsGroup => new ChartPoint<DateTime>
            //    {
            //        X = dsGroup.Key.AddHours(-12),
            //        Y = dsGroup.Sum(ds => ds.Y)
            //    })
            //    .ToList();

            //if (application.EndDate.Date > columnChartSeries.Last().X.Date)
            //{
            //    columnChartSeries.Add(new ChartPoint<DateTime>
            //    {
            //        X = application.EndDate.Date.AddHours(12),
            //        Y = columnChartSeries.Last().Y
            //    });
            //}

            var lineData =
                (await GetAmRateApplicationsAsync(application))
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
                        dates.Select(d => new
                        {
                            ChartPoint = new ChartPoint<DateTime, decimal>
                            {
                                X = d,
                                Y = aa.Rate.Value
                            }
                            ,Application = aa
                        })
                        .ToArray();

                    return data;
                })
                .GroupBy(cp => cp.ChartPoint.X)
                .Select(cpg => cpg.OrderByDescending(d => d.Application.BeginDate)
                                  .ThenBy(d => d.Application.Rate)
                                  .First()
                                  .ChartPoint)
                .OrderBy(cp => cp.X)
                .ToList();

            (await GetAmOzsApplicationsAsync(application))
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
            .ForEach(d => lineData.Where(cp => cp.X == d)
                                  .ToList()
                                  .ForEach(cp => cp.Y = 0.0m));

            //if (application.EndDate.Date > lineData.Last().X.Date)
            //{
            //    lineData.Add(new ChartPoint<DateTime, decimal>
            //    {
            //        X = application.EndDate.Date.AddHours(12),
            //        Y = lineData.Last().Y
            //    });
            //}





            var lineChart = new List<ChartSeries<DateTime, decimal>>
            {
                new ChartSeries<DateTime, decimal>
                {
                    Name = "",
                    Color = "#2F2FFB",
                    DataSource = lineData,
                    //SeriesType = Syncfusion.EJ2.Charts.ChartSeriesType.StepLine
                },
            };

            return lineChart;
        }





        public async Task<IEnumerable<RsApplication>> GetCrossingGridDataAsync(RsApplication application)
        {
            return await Task.Run(() => _repository.ReservationSystemApplications
                                                   .Where(a => a.Id != application.Id && a.IntersectsWith(application))
                                                   .ToArray());
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





        public async Task<IEnumerable<Rate>> GetRatesAsync()
        {
            return await Task.Run(() => Rate.Values
                                            .Where(r => r.Type != RateValueType.Unset)
                                            .ToArray());
        }





        public async Task<IEnumerable<RsApplication>> GetApplicationsAsync()
        {
            return await Task.Run(() => _repository.ReservationSystemApplications);
        }





        public async Task<IEnumerable<AmOzsApplication>> GetAmOzsApplicationsAsync(RsApplication application)
        {
            return await Task.Run(() => _repository.AmApplications
                                                   .OfType<AmOzsApplication>()
                                                   .Where(a => a.IntersectsWith(application))
                                                   .ToArray());
        }





        public async Task<IEnumerable<AmRateApplication>> GetAmRateApplicationsAsync(RsApplication application)
        {
            return await Task.Run(() => _repository.AmApplications
                                                   .OfType<AmRateApplication>()
                                                   .Where(a => a.IntersectsWith(application))
                                                   .ToArray());
        }





        public async Task<RsApplication> GetNewApplication()
        {
            return await Task.Run(() => new RsApplication
            {
                Candidate = _repository.People.Single(p => p.Id == 1) //Храмцов
            });
        }

    }

}
