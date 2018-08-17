using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SamProject.Models;





namespace SamProject.Repositories
{





    public class Repository
    {
        private static Random _random;
        private static Person[] _people;
        private static Client[] _clients;
        private static Project[] _projects;
        private static Application[] _applications;
        private static decimal[] _rates;





        static Repository()
        {
            var applicationStatusesCount = Enum.GetValues(typeof(ApplicationStatus)).Length;
            var qualificationsCount = Enum.GetValues(typeof(Qualification)).Length;
            var specialtiesCount = Enum.GetValues(typeof(Specialty)).Length;
            var startDate = new DateTime(2017, 1, 1);
            var endDate = new DateTime(2020, 12, 31);
            var daysSpan = (endDate - startDate).Days;
            const int peopleCount = 100;
            const int clientsCount = 10;
            const int projectsCount = 20;
            const int applicationsCount = 200;

            _random = new Random();

            _rates = new[] { 0.25m, 0.5m, 0.75m, 1.0m, 1.25m, 1.5m, 1.75m, 2.0m };

            _people = 
                Enumerable.Range(1, peopleCount)
                          .Select(i => new Person
                          {
                              Id = i,
                              Qualification = (Qualification)_random.Next(qualificationsCount),
                              Specialty = (Specialty)_random.Next(specialtiesCount),
                              FirstName = $"Firstname{i}",
                              LastName = $"Lastname{i}",
                              PatronymicName = $"Patronymicname{i}"
                          })
                          .ToArray();

            _clients = 
                Enumerable.Range(1, clientsCount)
                          .Select(i => new Client
                          {
                              Id = i,
                              Name = $"Client # {i}"
                          })
                          .ToArray();

            _projects = 
                Enumerable.Range(1, projectsCount)
                          .Select(i => new Project
                          {
                              Id = i,
                              Name = $"Project # {i}",
                              Client = _clients[_random.Next(_clients.Length)]
                          })
                          .ToArray();

            _applications = 
                Enumerable.Range(1, applicationsCount)
                          .Select(i =>
                          {
                              var bd = startDate.AddDays(_random.Next(daysSpan));
                              var ed = bd.AddDays(_random.Next((endDate - bd).Days + 1));

                              return new Application
                              {
                                  Id = i,
                                  Number = i + 1000000,
                                  ApplicationStatus = (ApplicationStatus) _random.Next(applicationStatusesCount),
                                  Project = _projects[_random.Next(_projects.Length)],
                                  Qualification = (Qualification) _random.Next(qualificationsCount),
                                  Specialty = (Specialty) _random.Next(specialtiesCount),
                                  Rate = _rates[_random.Next(_rates.Length)],
                                  Candidate = _people[_random.Next(_people.Length)],
                                  ProjectManager = _people[_random.Next(_people.Length)],
                                  Smd = _people[_random.Next(_people.Length)],
                                  BeginDate = bd,
                                  EndDate = ed
                              };
                          })
                          .ToArray();
        }





        public static IEnumerable<ChartData> GetColumnsData(DateTime date)
        {
            var columnChart = new[]
            {
                new ChartData
                {
                    Name = "project #1",
                    Color = "green",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(0), y = 0.5},
                        new {x = date.AddDays(1), y = 0.5},
                        new {x = date.AddDays(2), y = 0.5},
                        new {x = date.AddDays(3), y = 0.5},
                        new {x = date.AddDays(4), y = 0.5},
                        new {x = date.AddDays(5), y = 0.5},
                        new {x = date.AddDays(6), y = 0.5},
                        new {x = date.AddDays(7), y = 0.5},
                    }
                },
                new ChartData
                {
                    Name = "project #1 Internal",
                    Color = "gray",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(8), y = 0.25},
                        new {x = date.AddDays(9), y = 0.25},
                    }
                },
                new ChartData
                {
                    Name = "project #2",
                    Color = "yellow",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(1), y = 0.25},
                        new {x = date.AddDays(2), y = 0.25},
                        new {x = date.AddDays(3), y = 0.25},
                        new {x = date.AddDays(4), y = 0.25},
                    }
                },
                new ChartData
                {
                    Name = "project #3",
                    Color = "orange",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(3), y = 0.25},
                        new {x = date.AddDays(4), y = 0.25},
                        new {x = date.AddDays(5), y = 0.25},
                        new {x = date.AddDays(6), y = 0.25},
                        new {x = date.AddDays(7), y = 0.25},
                        new {x = date.AddDays(8), y = 0.25},
                        new {x = date.AddDays(9), y = 0.25},
                    }
                },
                new ChartData
                {
                    Name = "project #4",
                    Color = "red",
                    DataSource = new object[]
                    {
                        new {x = date.AddDays(4), y = 0.25},
                    }
                },
            };

            return columnChart;
        }





        public static IEnumerable<ChartData> GetAreaData(DateTime date = new DateTime())
        {
            var areaChart = new[]
            {
                new ChartData
                {
                    Name = "",
                    Color = "gray",
                    DataSource = new object[]
                    {
                        new {x = 0.0, y = 1.0},
                        new {x = 1.0, y = 1.0},
                        new {x = 2.0, y = 1.0},
                        new {x = 3.0, y = 1.0},
                    }
                },
                new ChartData
                {
                    Name = "",
                    Color = "gray",
                    DataSource = new object[]
                    {
                        new {x = 7.0, y = 1.0},
                        new {x = 8.0, y = 1.0},
                    }
                },
            };

            return areaChart;
        }





        public static IEnumerable<ChartData> GetLineData(DateTime date = new DateTime())
        {
            var lineChart = new[]
            {
                new ChartData
                {
                    Name = "",
                    Color = "black",
                    DataSource = new object[]
                    {
                        new {x = 0.0, y = 1.0},
                        new {x = 1.0, y = 1.0},
                        new {x = 2.0, y = 1.0},
                        new {x = 3.0, y = 1.0},
                        new {x = 4.0, y = 1.0},
                        new {x = 5.0, y = 1.0},
                        new {x = 6.0, y = 1.0},
                        new {x = 7.0, y = 1.0},
                        new {x = 8.0, y = 0.5},
                        new {x = 9.0, y = 0.5},
                        new {x = 10.0, y = 0.5},
                    }
                },
            };

            return lineChart;
        }





        public static IEnumerable<Application> GetGridData() => _applications;





    }






}
