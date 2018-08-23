using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SamProject.Models;





namespace SamProject.Repositories
{





    public class Repository
    {
        private static readonly Random _random;
        private static Person[] _people;
        private static Client[] _clients;
        private static Project[] _projects;
        private static Comment[] _comments;
        private static Application[] _applications;
        private static decimal[] _rates;
        private static List<ChartData<DateTime>> _columnChartData;




        public static IEnumerable<Comment> Comments => _comments;
        public static IEnumerable<Person> People => _people;
        public static IEnumerable<Client> Clients => _clients;
        public static IEnumerable<Project> Projects => _projects;
        public static IEnumerable<decimal> Rates => _rates;
        public static IEnumerable<Application> Applications => _applications;





        static Repository()
        {
            _random = new Random();
            _rates = new [] { 0.25m, 0.5m, 0.75m, 1.0m, 1.25m, 1.5m, 1.75m, 2.0m };

            _clients =
                Enumerable.Range(1, 4)
                          .Select(i => new Client
                          {
                              Id = i,
                              Name = $"Client # {i}"
                          })
                          .ToArray();

            _people = new []
            {
                new Person{ Id = 1, FirstName = "Владимир",  LastName = "Храмцов",      PatronymicName = "Валентинович",   Specialty = Specialty.Developer, Qualification = Qualification.Senior },
                new Person{ Id = 2, FirstName = "Александр", LastName = "Пригорницкий", PatronymicName = "Владимирович",   Specialty = Specialty.Pm,        Qualification = Qualification.Staff  },
                new Person{ Id = 3, FirstName = "Александр", LastName = "Слапенин",     PatronymicName = "Владимирович",   Specialty = Specialty.Pm,        Qualification = Qualification.Staff  },
                new Person{ Id = 4, FirstName = "Анна",      LastName = "Силкович",     PatronymicName = "Константиновна", Specialty = Specialty.Pm,        Qualification = Qualification.Staff  },
                new Person{ Id = 5, FirstName = "Алексей",   LastName = "Литвин",       PatronymicName = "Вячеславович",   Specialty = Specialty.Smd,       Qualification = Qualification.Staff  },
                new Person{ Id = 6, FirstName = "Александр", LastName = "Сидоренко",    PatronymicName = "Иванович",       Specialty = Specialty.Smd,       Qualification = Qualification.Staff  },
            };

            _projects = new []
            {
                new Project{ Id = 1, Name = "SocialVOYCE",       Client = _clients[0], Department = "PC09", Market = "DE" },
                new Project{ Id = 2, Name = "Telemovil_Presale", Client = _clients[1], Department = "PC09", Market = "DE" },
                new Project{ Id = 3, Name = "EOAPP",             Client = _clients[2], Department = "PC09", Market = "DE" },
                new Project{ Id = 4, Name = "moweb_presale",     Client = _clients[3], Department = "PC09", Market = "DE" },
            };

            _applications = new []
            {
                new Application{ Id = 1,  Number = "6801", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[3], BeginDate = new DateTime(2018, 1, 1),  EndDate = new DateTime(2018, 12, 31) },
                new Application{ Id = 2,  Number = "6898", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[1], Candidate = _people[0], ProjectManager = _people[4], Smd = _people[4], Specialty = Specialty.Developer, Qualification = Qualification.Senior, Rate = _rates[0], BeginDate = new DateTime(2018, 1, 8),  EndDate = new DateTime(2018, 1, 8)   },
                new Application{ Id = 3,  Number = "6920", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[1], Candidate = _people[0], ProjectManager = _people[4], Smd = _people[4], Specialty = Specialty.Developer, Qualification = Qualification.Senior, Rate = _rates[0], BeginDate = new DateTime(2018, 1, 9),  EndDate = new DateTime(2018, 1, 9)   },
                new Application{ Id = 4,  Number = "6921", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 1, 11), EndDate = new DateTime(2018, 1, 12)  },
                new Application{ Id = 5,  Number = "6934", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[3], Candidate = _people[0], ProjectManager = _people[3], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Senior, Rate = _rates[0], BeginDate = new DateTime(2018, 1, 15), EndDate = new DateTime(2018, 1, 15)  },
                new Application{ Id = 6,  Number = "7050", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 2, 12), EndDate = new DateTime(2018, 2, 16)  },
                new Application{ Id = 7,  Number = "7134", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 2, 27), EndDate = new DateTime(2018, 2, 28)  },
                new Application{ Id = 8,  Number = "7211", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 3, 13), EndDate = new DateTime(2018, 3, 14)  },
                new Application{ Id = 9,  Number = "7237", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 3, 21), EndDate = new DateTime(2018, 3, 22)  },
                new Application{ Id = 10, Number = "7251", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 3, 27), EndDate = new DateTime(2018, 3, 28)  },
                new Application{ Id = 11, Number = "7319", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 4, 3),  EndDate = new DateTime(2018, 4, 4)   },
                new Application{ Id = 12, Number = "7516", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 5, 21), EndDate = new DateTime(2018, 5, 28)  },
                new Application{ Id = 13, Number = "7536", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 5, 29), EndDate = new DateTime(2018, 5, 30)  },
                new Application{ Id = 14, Number = "7630", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[1], BeginDate = new DateTime(2018, 6, 6),  EndDate = new DateTime(2018, 6, 6)   },
                new Application{ Id = 15, Number = "7632", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 6, 7),  EndDate = new DateTime(2018, 6, 7)   },
                new Application{ Id = 16, Number = "7651", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 6, 13), EndDate = new DateTime(2018, 6, 14)  },
                new Application{ Id = 17, Number = "7665", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 6, 20), EndDate = new DateTime(2018, 6, 21)  },
                new Application{ Id = 18, Number = "7685", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 6, 25), EndDate = new DateTime(2018, 6, 26)  },
                new Application{ Id = 19, Number = "7721", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 7, 4),  EndDate = new DateTime(2018, 7, 5)   },
                new Application{ Id = 20, Number = "7768", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 7, 9),  EndDate = new DateTime(2018, 7, 10)  },
                new Application{ Id = 21, Number = "7832", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 7, 27), EndDate = new DateTime(2018, 7, 30)  },
                new Application{ Id = 22, Number = "7949", Department = "PC09", Market = "DE", ApplicationStatus = ApplicationStatus.Approved, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], Specialty = Specialty.Developer, Qualification = Qualification.Staff,  Rate = _rates[0], BeginDate = new DateTime(2018, 8, 8),  EndDate = new DateTime(2018, 8, 9)   },
            };

            _comments = Enumerable.Range(1, 20)
                                  .Select(i => new Comment
                                  {
                                      Id = i,
                                      Content = "Длинный комментарий, оставленный пользователем, длинный комментарий, оставленный пользователем, длинный комментарий, оставленный пользователем, длинный комментарий, оставленный пользователем",
                                      Person = _people[_random.Next(1, _people.Length)],
                                      DateTimeOfPosting = DateTime.Now,
                                      DateTimeOfModify = DateTime.Now
                                  })
                                  .ToArray();
        }





        public static IEnumerable<ChartData<DateTime>> GetColumnsData(Application application)
        {
            var colors = new [] { "green", "gray", "yellow", "orange", "red", };

            var columnChart =
                _applications.Where(app => app.Id == application.Id 
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

                                 var chartData = new ChartData<DateTime>
                                 {
                                     Name = appGroup.Key.Name,
                                     Color = colors[i],
                                     DataSource = source
                                 };

                                 return chartData;
                             })
                             .ToList();

            _columnChartData = columnChart;

            return columnChart;
        }





        public static IEnumerable<ChartData<double>> GetLineData(Application application)
        {
            if (_columnChartData is null)
            {
                GetColumnsData(application); //todo return
            }


            var linedata =
                _columnChartData.SelectMany(cd => cd.DataSource)
                                .GroupBy(ds => ds.X)
                                .Select((dsGroup, i) => new ChartPoint<double>
                                {
                                    X = i,
                                    Y = dsGroup.Sum(ds => ds.Y)
                                })
                                .ToArray();

            if (application.Id == 1)
            {
                linedata.Where(cp => cp.X > 90 && cp.X < 101)
                        .ToList()
                        .ForEach(cp => cp.Y -= 0.25);

                linedata.Where(cp => cp.X > 140 && cp.X < 151)
                        .ToList()
                        .ForEach(cp => cp.Y -= 0.5);

                linedata.Where(cp => cp.X > 30 && cp.X < 51)
                        .ToList()
                        .ForEach(cp => cp.Y = 0.0);

                linedata.Where(cp => cp.X > 190 && cp.X < 201)
                        .ToList()
                        .ForEach(cp => cp.Y = 0.0);

                linedata.Where(cp => cp.X > 250 && cp.X < 271)
                        .ToList()
                        .ForEach(cp => cp.Y = 0.0);

                linedata.Where(cp => cp.X > 330)
                        .ToList()
                        .ForEach(cp => cp.Y += 0.25);
            }


            var lineChart = new[]
            {
                new ChartData<double>
                {
                    Name = "",
                    Color = "black",
                    DataSource = linedata
                },
            };

            return lineChart;
        }






        public static IEnumerable<Application> GetCrossingGridData(Application app)
        {
 
            return _applications.Where(a => 1==1).ToArray();
        }






        private static bool AreApplicationsCrossing(Application app1, Application app2)
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
    }






}
