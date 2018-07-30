using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jqwTest.Models;

namespace jqwTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 1,
                    ManagerID = 2,
                    FirstName = "Nancy",
                    LastName = "Davolio",
                    Title = "Sales Representative",
                    Address = "USA Seattle 507 - 20th Ave. E.Apt. 2A",
                    City = "Seattle",
                    Country = "USA",
                    BirthDate = new DateTime(1990, 2, 8),
                    HireDate = new DateTime(2010, 5, 6)
                },
                new Employee
                {
                    EmployeeID = 2,
                    ManagerID = null,
                    FirstName = "Andrew",
                    LastName = "Fuller",
                    Title = "Vice President",
                    Address = "908 W.Capital Way",
                    City = "Kirkland",
                    Country = "USA",
                    BirthDate = new DateTime(1992, 5, 7),
                    HireDate = new DateTime(2011, 4, 30)
                },
                new Employee
                {
                    EmployeeID = 3,
                    ManagerID = 2,
                    FirstName = "Janet",
                    LastName = "Callahan",
                    Title = "Sales Representative",
                    Address = "UK London  Coventry House Miner Rd.",
                    City = "London",
                    Country = "UK",
                    BirthDate = new DateTime(1991, 2, 22),
                    HireDate = new DateTime(2012, 5, 25)
                },
                new Employee
                {
                    EmployeeID = 4,
                    ManagerID = 2,
                    FirstName = "Margaret",
                    LastName = "King",
                    Title = "Sales Manager",
                    Address = "Edgeham Hollow Winchester Way",
                    City = "London",
                    Country = "UK",
                    BirthDate = new DateTime(1992, 3, 1),
                    HireDate = new DateTime(2014, 5, 8)
                },
                new Employee
                {
                    EmployeeID = 5,
                    ManagerID = 2,
                    FirstName = "Steven",
                    LastName = "Buchanan",
                    Title = "Sales Representative",
                    Address = "7 Houndstooth Rd.	11",
                    City = "London",
                    Country = "UK",
                    BirthDate = new DateTime(1993, 2, 3),
                    HireDate = new DateTime(2015, 3, 6)
                },
                new Employee
                {
                    EmployeeID = 6,
                    ManagerID = 5,
                    FirstName = "Robert",
                    LastName = "King",
                    Title = "Sales Representative",
                    Address = "USA Seattle 507 - 20th Ave. E.Apt. 2A",
                    City = "Seattle",
                    Country = "USA",
                    BirthDate = new DateTime(1991, 9, 18),
                    HireDate = new DateTime(2012, 8, 2)
                },
                new Employee
                {
                    EmployeeID = 7,
                    ManagerID = 5,
                    FirstName = "Anne",
                    LastName = "Dodsworth",
                    Title = "Inside Sales Coordinator",
                    Address = "4726 - 11th Ave",
                    City = "Seattle",
                    Country = "USA",
                    BirthDate = new DateTime(1980, 8, 8),
                    HireDate = new DateTime(2010, 1, 3)
                },
                new Employee
                {
                    EmployeeID = 8,
                    ManagerID = 2,
                    FirstName = "Michael",
                    LastName = "Richards",
                    Title = "Sales Representative",
                    Address = "6126 - 16th Ave",
                    City = "Seattle",
                    Country = "USA",
                    BirthDate = new DateTime(1993, 3, 6),
                    HireDate = new DateTime(2009, 7, 9)
                }
            };






            ViewBag.Employees = employees;
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }







    public class Employee
    {
        public int EmployeeID
        {
            get;
            set;
        }
        public int? ManagerID
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public DateTime HireDate
        {
            get;
            set;
        }
        public DateTime BirthDate
        {
            get;
            set;
        }
    }
}
