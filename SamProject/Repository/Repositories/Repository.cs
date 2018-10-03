using System;
using System.Collections.Generic;
using System.Linq;

using Repository.Models;





namespace Repository.Repositories
{





    public class Repository : IRepository
    {
        private static readonly Random _random = new Random();
        private static readonly Person[] _people;
        private static readonly Client[] _clients;
        private static readonly Project[] _projects;
        private static readonly Comment[] _comments;
        private static readonly RsApplication[] _reservationSystemApplications;
        private static readonly AmApplication[] _amApplications;
        




        public IEnumerable<Comment> Comments => _comments;
        public IEnumerable<Person> People => _people;
        public IEnumerable<Client> Clients => _clients;
        public IEnumerable<Project> Projects => _projects;
        public IEnumerable<RsApplication> ReservationSystemApplications => _reservationSystemApplications;
        public IEnumerable<AmApplication> AmApplications => _amApplications;





        static Repository()
        {
            _clients = new []
            {
                new Client{ Id = 1, Name = "Voycer AG" },
                new Client{ Id = 2, Name = "TELEMOVIL INC." },
                new Client{ Id = 3, Name = "EOMAP GmbH&Co.KG" },
                new Client{ Id = 4, Name = "mo'web GmbH" },
            };

            _people = new []
            {
                new Person{ Id = 1, FirstName = "Владимир",  LastName = "Храмцов",      PatronymicName = "Валентинович",   Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Senior }},
                new Person{ Id = 2, FirstName = "Александр", LastName = "Пригорницкий", PatronymicName = "Владимирович",   Specialty = new Specialty{ Type = SpecialtyType.Pm        }, Qualification = new Qualification{ Type = QualificationType.Staff  }},
                new Person{ Id = 3, FirstName = "Александр", LastName = "Слапенин",     PatronymicName = "Владимирович",   Specialty = new Specialty{ Type = SpecialtyType.Pm        }, Qualification = new Qualification{ Type = QualificationType.Staff  }},
                new Person{ Id = 4, FirstName = "Анна",      LastName = "Силкович",     PatronymicName = "Константиновна", Specialty = new Specialty{ Type = SpecialtyType.Pm        }, Qualification = new Qualification{ Type = QualificationType.Staff  }},
                new Person{ Id = 5, FirstName = "Алексей",   LastName = "Литвин",       PatronymicName = "Вячеславович",   Specialty = new Specialty{ Type = SpecialtyType.Smd       }, Qualification = new Qualification{ Type = QualificationType.Staff  }},
                new Person{ Id = 6, FirstName = "Александр", LastName = "Сидоренко",    PatronymicName = "Иванович",       Specialty = new Specialty{ Type = SpecialtyType.Smd       }, Qualification = new Qualification{ Type = QualificationType.Staff  }},
            };

            _projects = new []
            {
                new Project{ Id = 1, Name = "SocialVOYCE",       Client = _clients[0], Department = "PC09", Market = "DE" , ProjectManager = _people[1], Smd = _people[5] },
                new Project{ Id = 2, Name = "Telemovil_Presale", Client = _clients[1], Department = "PC09", Market = "USA", ProjectManager = _people[4], Smd = _people[4] },
                new Project{ Id = 3, Name = "EOAPP",             Client = _clients[2], Department = "PC09", Market = "DE" , ProjectManager = _people[2], Smd = _people[5] },
                new Project{ Id = 4, Name = "moweb_presale",     Client = _clients[3], Department = "PC09", Market = "DE" , ProjectManager = _people[3], Smd = _people[5] },
            };

            var description = "Подробное описание кандидата";

            _reservationSystemApplications = new []
            {
                new RsApplication{ Id = 1,  Number = "6801", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 1.0m },  BeginDate = new DateTime(2018, 1, 1),  EndDate = new DateTime(2018, 12, 31) },
                new RsApplication{ Id = 2,  Number = "6898", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[1], Candidate = _people[0], ProjectManager = _people[4], Smd = _people[4], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Senior}, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 1, 8),  EndDate = new DateTime(2018, 1, 8)   },
                new RsApplication{ Id = 3,  Number = "6920", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[1], Candidate = _people[0], ProjectManager = _people[4], Smd = _people[4], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Senior}, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 1, 9),  EndDate = new DateTime(2018, 1, 9)   },
                new RsApplication{ Id = 4,  Number = "6921", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 1, 11), EndDate = new DateTime(2018, 1, 12)  },
                new RsApplication{ Id = 5,  Number = "6934", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[3], Candidate = _people[0], ProjectManager = _people[3], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Senior}, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 1, 15), EndDate = new DateTime(2018, 1, 15)  },
                new RsApplication{ Id = 6,  Number = "7050", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 2, 12), EndDate = new DateTime(2018, 2, 16)  },
                new RsApplication{ Id = 7,  Number = "7134", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 2, 27), EndDate = new DateTime(2018, 2, 28)  },
                new RsApplication{ Id = 8,  Number = "7211", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 3, 13), EndDate = new DateTime(2018, 3, 14)  },
                new RsApplication{ Id = 9,  Number = "7237", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 3, 21), EndDate = new DateTime(2018, 3, 22)  },
                new RsApplication{ Id = 10, Number = "7251", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 3, 27), EndDate = new DateTime(2018, 3, 28)  },
                new RsApplication{ Id = 11, Number = "7319", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 4, 3),  EndDate = new DateTime(2018, 4, 4)   },
                new RsApplication{ Id = 12, Number = "7516", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 5, 21), EndDate = new DateTime(2018, 5, 28)  },
                new RsApplication{ Id = 13, Number = "7536", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 5, 29), EndDate = new DateTime(2018, 5, 30)  },
                new RsApplication{ Id = 14, Number = "7630", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.5m },  BeginDate = new DateTime(2018, 6, 6),  EndDate = new DateTime(2018, 6, 6)   },
                new RsApplication{ Id = 15, Number = "7632", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 6, 7),  EndDate = new DateTime(2018, 6, 7)   },
                new RsApplication{ Id = 16, Number = "7651", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 6, 13), EndDate = new DateTime(2018, 6, 14)  },
                new RsApplication{ Id = 17, Number = "7665", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 6, 20), EndDate = new DateTime(2018, 6, 21)  },
                new RsApplication{ Id = 18, Number = "7685", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 6, 25), EndDate = new DateTime(2018, 6, 26)  },
                new RsApplication{ Id = 19, Number = "7721", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 7, 4),  EndDate = new DateTime(2018, 7, 5)   },
                new RsApplication{ Id = 20, Number = "7768", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 7, 9),  EndDate = new DateTime(2018, 7, 10)  },
                new RsApplication{ Id = 21, Number = "7832", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[2], Candidate = _people[0], ProjectManager = _people[2], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 7, 27), EndDate = new DateTime(2018, 7, 30)  },
                new RsApplication{ Id = 22, Number = "7949", Department = "PC09", ApplicationStatus = new RsApplicationStatus{ Type = RsApplicationStatusType.Approved }, Project = _projects[0], Candidate = _people[0], ProjectManager = _people[1], Smd = _people[5], CandidateDescription = description, Specialty = new Specialty{ Type = SpecialtyType.Developer }, Qualification = new Qualification{ Type = QualificationType.Staff }, Rate = new Rate { Value = 0.25m }, BeginDate = new DateTime(2018, 8, 8),  EndDate = new DateTime(2018, 8, 9)   },
            };

            _comments = 
                Enumerable.Range(1, 20)
                          .Select(i => new Comment
                          {
                              Id = i,
                              Content = "Длинный комментарий, оставленный пользователем, длинный комментарий, оставленный пользователем, длинный комментарий, оставленный пользователем, длинный комментарий, оставленный пользователем",
                              Person = _people[_random.Next(1, _people.Length)],
                              DateTimeOfPosting = DateTime.Now,
                              DateTimeOfModify = DateTime.Now
                          })
                          .ToArray();

            _amApplications = new AmApplication []
            {
                new AmOzsApplication{ Id = 1, Number = "01-000001", BeginDate = new DateTime(2018, 1, 21), EndDate = new DateTime(2018, 1, 30), Person = _people[0] },
                new AmOzsApplication{ Id = 2, Number = "01-000002", BeginDate = new DateTime(2018, 5, 11), EndDate = new DateTime(2018, 5, 24), Person = _people[0] },
                new AmOzsApplication{ Id = 3, Number = "01-000003", BeginDate = new DateTime(2018, 9, 1),  EndDate = new DateTime(2018, 9, 20), Person = _people[0] },

                new AmRateApplication{ Id = 4,  Number = "02-000001", BeginDate = new DateTime(2018, 1, 1),   EndDate = new DateTime(2018, 12, 31), Person = _people[0], Rate = new Rate { Value = 1.0m }  },
                new AmRateApplication{ Id = 5,  Number = "02-000002", BeginDate = new DateTime(2018, 1, 8),   EndDate = new DateTime(2018, 1, 9),   Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 6,  Number = "02-000003", BeginDate = new DateTime(2018, 1, 11),  EndDate = new DateTime(2018, 1, 12),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 7,  Number = "02-000004", BeginDate = new DateTime(2018, 1, 15),  EndDate = new DateTime(2018, 1, 15),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 8,  Number = "02-000005", BeginDate = new DateTime(2018, 2, 12),  EndDate = new DateTime(2018, 2, 16),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 9,  Number = "02-000006", BeginDate = new DateTime(2018, 2, 27),  EndDate = new DateTime(2018, 2, 28),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 10, Number = "02-000007", BeginDate = new DateTime(2018, 3, 13),  EndDate = new DateTime(2018, 3, 14),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 11, Number = "02-000008", BeginDate = new DateTime(2018, 3, 21),  EndDate = new DateTime(2018, 3, 22),  Person = _people[0], Rate = new Rate { Value = 1.5m }  },
                new AmRateApplication{ Id = 12, Number = "02-000009", BeginDate = new DateTime(2018, 3, 27),  EndDate = new DateTime(2018, 3, 28),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 13, Number = "02-000010", BeginDate = new DateTime(2018, 4, 2),   EndDate = new DateTime(2018, 4, 6),   Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 14, Number = "02-000011", BeginDate = new DateTime(2018, 5, 21),  EndDate = new DateTime(2018, 5, 28),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 15, Number = "02-000012", BeginDate = new DateTime(2018, 5, 29),  EndDate = new DateTime(2018, 5, 30),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 16, Number = "02-000013", BeginDate = new DateTime(2018, 6, 6),   EndDate = new DateTime(2018, 6, 6),   Person = _people[0], Rate = new Rate { Value = 1.5m }  },
                new AmRateApplication{ Id = 17, Number = "02-000014", BeginDate = new DateTime(2018, 6, 7),   EndDate = new DateTime(2018, 6, 7),   Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 18, Number = "02-000015", BeginDate = new DateTime(2018, 6, 13),  EndDate = new DateTime(2018, 6, 14),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 19, Number = "02-000016", BeginDate = new DateTime(2018, 6, 20),  EndDate = new DateTime(2018, 6, 21),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 20, Number = "02-000017", BeginDate = new DateTime(2018, 6, 25),  EndDate = new DateTime(2018, 6, 26),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 21, Number = "02-000018", BeginDate = new DateTime(2018, 7, 4),   EndDate = new DateTime(2018, 7, 5),   Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 22, Number = "02-000019", BeginDate = new DateTime(2018, 7, 9),   EndDate = new DateTime(2018, 7, 10),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 23, Number = "02-000020", BeginDate = new DateTime(2018, 7, 27),  EndDate = new DateTime(2018, 7, 30),  Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 24, Number = "02-000021", BeginDate = new DateTime(2018, 8, 8),   EndDate = new DateTime(2018, 8, 9),   Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 25, Number = "02-000022", BeginDate = new DateTime(2018, 10, 1),  EndDate = new DateTime(2018, 10, 31), Person = _people[0], Rate = new Rate { Value = 1.25m } },
                new AmRateApplication{ Id = 26, Number = "02-000023", BeginDate = new DateTime(2018, 11, 13), EndDate = new DateTime(2018, 11, 27), Person = _people[0], Rate = new Rate { Value = 0.5m }  },
            };
        }






    }






}
