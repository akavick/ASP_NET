using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HowToBeatNPM_1.Classes;
using Microsoft.AspNetCore.Mvc;
using HowToBeatNPM_1.Models;
using HowToBeatNPM_1.Repositories;

namespace HowToBeatNPM_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.datasource = Repository.Records;

            return View();
        }









        public IActionResult UrlDatasource([FromBody]dynamic dm)
        {
            var dataSource = Repository.Records;
            int count = dataSource.Count;

            return (bool)dm.requiresCounts ? Json(new { result = dataSource.Skip((int)dm.skip).Take((int)dm.take).ToList(), count = count }) : Json(dataSource);
        }

        public class DataResult
        {
            public List<Record> Result { get; set; }
            public int Count { get; set; }
        }


        public ActionResult Insert([FromBody]Record value)
        {
            return Json(value);
        }
        public ActionResult Update([FromBody]Record value)
        {
            return Json(value);
        }
        public ActionResult Delete([FromBody]Record value)
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











        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
