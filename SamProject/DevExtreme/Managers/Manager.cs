using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DevExtreme.Models;

using Repository.Models;
using Repository.Repositories;





namespace DevExtreme.Managers
{

    public class Manager : IManager
    {
        private readonly IRepository _repository;





        public Manager(IRepository repository)
        {
            _repository = repository;
        }





        public async Task<IEnumerable<ChartData<DateTime>>> GetColumnsDataAsync(RsApplication application)
        {
            return await Task.Run(() =>
            {
                var dateSpan = new DateSpan
                {
                    BeginDate = application.BeginDate.AddDays(-1),
                    EndDate = application.EndDate.AddDays(1)
                };

                var colors = new[] { "green", "darkred", "darkgray", "darkorange", "lightblue", "darkblue" };

                var columnChart =
                    _repository.ReservationSystemApplications
                               .Where(app => app.IntersectsWith(dateSpan))
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
                                                   Y = (double)innerApp.Rate.Value,
                                                   RsApplicationId = innerApp.Id,
                                                   RsApplicationNumber = innerApp.Number
                                               })
                                               .ToArray();

                                           return data;
                                       })
                                       .ToList();

                                   var chartData = new ChartData<DateTime>
                                   {
                                       Name = appGroup.Key.Name,
                                       Color = colors[i],
                                       DataSource = source,
                                       //SeriesType = Syncfusion.EJ2.Charts.ChartSeriesType.StackingColumn
                                   };

                                   return chartData;
                               })
                               .ToList();

                return columnChart;
            });
        }





        public async Task<IEnumerable<ChartData<DateTime>>> GetLineDataAsync(RsApplication application)
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
                            ChartPoint = new ChartPoint<DateTime>
                            {
                                X = d.AddHours(-12),
                                Y = (double)aa.Rate.Value
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
            .ForEach(d => lineData.Where(cp => cp.X == d.AddHours(-12))
                                  .ToList()
                                  .ForEach(cp => cp.Y = 0.0));

            if (application.EndDate.Date > lineData.Last().X.Date)
            {
                lineData.Add(new ChartPoint<DateTime>
                {
                    X = application.EndDate.Date.AddHours(12),
                    Y = lineData.Last().Y
                });
            }





            var lineChart = new List<ChartData<DateTime>>
            {
                new ChartData<DateTime>
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
            return await Task.FromResult(_repository.ReservationSystemApplications
                                                   .Where(a => a.Id != application.Id && a.IntersectsWith(application))
                                                   .ToArray());
        }





        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await Task.FromResult(_repository.Comments);
        }





        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await Task.FromResult(_repository.People);
        }





        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await Task.FromResult(_repository.Clients);
        }





        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await Task.FromResult(_repository.Projects);
        }





        public async Task<IEnumerable<Rate>> GetRatesAsync()
        {
            return await Task.FromResult(Rate.Values
                                            .Where(r => r.Type != RateValueType.Unset)
                                            .ToArray());
        }





        public async Task<IEnumerable<RsApplication>> GetApplicationsAsync()
        {
            return await Task.FromResult(_repository.ReservationSystemApplications);
        }





        public async Task<IEnumerable<AmOzsApplication>> GetAmOzsApplicationsAsync(RsApplication application)
        {
            return await Task.FromResult(_repository.AmApplications
                                                   .OfType<AmOzsApplication>()
                                                   .Where(a => a.IntersectsWith(application))
                                                   .ToArray());
        }





        public async Task<IEnumerable<AmRateApplication>> GetAmRateApplicationsAsync(RsApplication application)
        {
            return await Task.FromResult(_repository.AmApplications
                                                   .OfType<AmRateApplication>()
                                                   .Where(a => a.IntersectsWith(application))
                                                   .ToArray());
        }





        public async Task<RsApplication> GetNewApplication()
        {
            return await Task.FromResult(new RsApplication
            {
                Candidate = _repository.People.Single(p => p.Id == 1) //Храмцов
            });
        }

    }

}
