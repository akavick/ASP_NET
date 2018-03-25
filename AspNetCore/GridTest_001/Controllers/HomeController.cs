using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GridTest_001.Models;
using GridTest_001.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GridTest_001.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.DataSource = Repository.Persons.ToList();

            return View();
        }











        #region Source

        public class GridControlValue
        {
            public int Skip { get; set; }
            public int Take { get; set; }
            public bool RequiresCounts { get; set; }
        }



        public IActionResult UrlDatasource([FromBody]GridControlValue gcv)
        {
            var dataSource = Repository.Persons.ToList();
            var res = dataSource.Skip(gcv.Skip)
                                .Take(gcv.Take)
                                .ToList();

            var urlDatasource = gcv.RequiresCounts
                                    ? Json(new { result = res, count = dataSource.Count })
                                    : Json(dataSource);
            return urlDatasource;
        }

        #endregion










        #region BATCH

        public class BatchSubmitValue
        {
            public List<Person> Added { get; set; }
            public List<Person> Changed { get; set; }
            public List<Person> Deleted { get; set; }
            public object Key { get; set; }
        }

        public IActionResult BatchUpdate([FromBody]BatchSubmitValue bsv)
        {
            if (bsv.Changed != null && bsv.Changed.Count > 0)
            {
                foreach (var person in bsv.Changed)
                {
                    var val = Repository.Persons.FirstOrDefault(p => p.Id == person.Id);
                    if (val != null)
                    {
                        val.Id = person.Id;
                        val.FirstName = person.FirstName;
                        val.LastName = person.LastName;
                    }
                }
            }

            if (bsv.Added != null && bsv.Added.Count > 0)
            {
                foreach (var person in bsv.Added)
                {
                    person.Id = Repository.ProduceId();
                    Repository.Persons.Insert(0, person);
                }
            }

            if (bsv.Deleted != null && bsv.Deleted.Count > 0)
            {
                foreach (var person in bsv.Deleted)
                {
                    Repository.Persons.Remove(Repository.Persons.FirstOrDefault(p => p.Id == person.Id));
                }
            }


            var dataSource = Repository.Persons.ToList();
            return Json(new { result = dataSource, count = dataSource.Count });
        }

        #endregion











        #region Standart

        public IActionResult Insert([FromBody]Person value)
        {
            return Json(value);
        }
        public IActionResult Update([FromBody]Person value)
        {
            return Json(value);
        }
        public IActionResult Delete([FromBody]Person value)
        {
            return Json(value);
        }

        #endregion










        #region CRUD

        public class CrudSubmitValue
        {

            public object Key { get; set; }
            public string Action { get; set; }
        }

        public IActionResult CrudUpdate([FromBody]dynamic crudSubmitValue)
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

            return Json(crudSubmitValue);
        }

        #endregion
















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
