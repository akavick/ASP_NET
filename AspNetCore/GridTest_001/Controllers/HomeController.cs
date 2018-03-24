using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GridTest_001.Models;
using GridTest_001.Repositories;

namespace GridTest_001.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.DataSource = Repository.Persons.ToList();

            return View();
        }














        public ActionResult BatchUpdate([FromBody]SubmitValue myObject)
        {
            if (myObject.Changed != null && myObject.Changed.Count > 0)
            {
                foreach (var person in myObject.Changed)
                {
                    Person val = Repository.Persons.FirstOrDefault(p => p.Id == person.Id);
                    if (val != null)
                    {
                        val.Id = person.Id;
                        val.FirstName = person.FirstName;
                        val.LastName = person.LastName;
                    }
                }
            }

            if (myObject.Added != null && myObject.Added.Count > 0)
            {
                foreach (var person in myObject.Added)
                {
                    Repository.Persons.Insert(0, person);
                }
            }

            if (myObject.Deleted != null && myObject.Deleted.Count > 0)
            {
                foreach (var person in myObject.Deleted)
                {
                    Repository.Persons.Remove(Repository.Persons.FirstOrDefault(p => p.Id == person.Id));
                }
            }

            var data = Repository.Persons;
            return Json(data);
        }



        public class SubmitValue
        {
            public List<Person> Added { get; set; }
            public List<Person> Changed { get; set; }
            public List<Person> Deleted { get; set; }
            public object Key { get; set; }
        }






        public IActionResult UrlDatasource([FromBody]dynamic dm)
        {
            var dataSource = Repository.Persons;
            var res = dataSource.Skip((int)dm.skip)
                                .Take((int)dm.take)
                                .ToArray();

            return (bool)dm.requiresCounts
                       ? Json(new { Result = res, dataSource.Count })
                       : Json(dataSource);
        }

        public class DataResult
        {
            public List<Person> Result { get; set; }
            public int Count { get; set; }
        }


        public ActionResult Insert([FromBody]Person value)
        {
            return Json(value);
        }
        public ActionResult Update([FromBody]Person value)
        {
            return Json(value);
        }
        public ActionResult Delete([FromBody]Person value)
        {
            return Json(value);
        }


        public ActionResult CrudUpdate([FromBody]dynamic value, string action)
        {
            //if (action == "update")
            //{
            //    //Update record in database
            //}
            //else if (action == "insert")
            //{
            //    //Insert record in database
            //}
            //else
            //{
            //    //Delete record in database
            //}

            //return Json(value, JsonRequestBehavior.AllowGet);

            return null;
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
