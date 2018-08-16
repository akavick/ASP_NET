using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SamProject.Models;





namespace SamProject.Repositories
{





    public class Repository
    {
        private static Person[] _people;
        private static Client[] _clients;
        private static Project[] _projects;
        private static Application[] _applications;




        static Repository()
        {
            _people = new[]
            {
                new Person{},
                new Person{},
                new Person{},
                new Person{},
                new Person{},
                new Person{},
                new Person{},
                new Person{},
                new Person{},
                new Person{},
            };

            _clients = new[]
            {
                new Client { Id = 1, Name = "Client # 1" },
                new Client { Id = 2, Name = "Client # 2" },
                new Client { Id = 3, Name = "Client # 3" },
                new Client { Id = 4, Name = "Client # 4" },
                new Client { Id = 5, Name = "Client # 5" },
            };

            _projects = new[]
            {
                new Project { Id = 1, Name = "Project # 1", Client = _clients[3] },
                new Project { Id = 2, Name = "Project # 2", Client = _clients[1] },
                new Project { Id = 3, Name = "Project # 3", Client = _clients[4] },
                new Project { Id = 4, Name = "Project # 4", Client = _clients[0] },
                new Project { Id = 5, Name = "Project # 5", Client = _clients[2] },
            };

            _applications = new[]
            {
                new Application {Id = 1, Project = _projects[4]},
                new Application {Id = 2, Project = _projects[0]},
                new Application {Id = 3, Project = _projects[3]},
                new Application {Id = 4, Project = _projects[1]},
                new Application {Id = 5, Project = _projects[2]},
            };
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
