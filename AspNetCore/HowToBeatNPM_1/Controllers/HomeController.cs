using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HowToBeatNPM_1.Classes;
using Microsoft.AspNetCore.Mvc;
using HowToBeatNPM_1.Models;
using HowToBeatNPM_1.Repositories;
using Syncfusion.EJ2;
using Newtonsoft.Json;
using Syncfusion.EJ2.Grids;


namespace HowToBeatNPM_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.DataSource = Repository.Records;

            //new EJ2(null, HttpContext).Calendar("asdasdasd");



            return View();
        }


        public ActionResult BatchUpdate([FromBody]Submitvalue myObject)
        {
            if (myObject.Changed != null && myObject.Changed.Count > 0)
            {
                foreach (var temp in myObject.Changed)
                {
                    var ord = temp;
                    Record val = Repository.Records.FirstOrDefault(or => or.RecordId == ord.RecordId);
                    val.RecordId = ord.RecordId;
                    //val.EmployeeID = ord.EmployeeID;
                    val.Customers = ord.Customers;
                    val.Freight = ord.Freight;
                    val.OrderDate = ord.OrderDate;
                    val.ShippedDate = ord.ShippedDate;
                    val.OrderId = ord.OrderId;
                    val.ShipCountry = ord.ShipCountry;
                }
            }
            if (myObject.Added != null && myObject.Added.Count > 0)
            {
                foreach (var temp in myObject.Added)
                {
                    Repository.Records.Insert(0, temp);
                }
            }
            if (myObject.Deleted != null && myObject.Deleted.Count > 0)
            {
                foreach (var temp in myObject.Deleted)
                {
                    Repository.Records.Remove(Repository.Records.FirstOrDefault(or => or.RecordId == temp.RecordId));
                }
            }

            var data = Repository.Records;
            return Json(data);
        }
        public class Submitvalue
        {
            public List<Record> Added { get; set; }
            public List<Record> Changed { get; set; }
            public List<Record> Deleted { get; set; }
            public object Key { get; set; }
        }






        public IActionResult UrlDatasource([FromBody]dynamic dm)
        {
            var dataSource = Repository.Records;
            int count = dataSource.Count;
            var res = dataSource.Skip((int) dm.skip).Take((int) dm.take).ToList();

            return (bool)dm.requiresCounts 
                       ? Json(new { result = res, count }) 
                       : Json(dataSource);
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















































        //public static List<Record> RecData = new List<Record>();

        //public IActionResult Index()
        //{
        //    if (RecData.Count == 0)
        //        BindData();
        //    ViewBag.data = EmployeeID;
        //    return View();
        //}
        //public void BindData()
        //{
        //    int code = 10000;
        //    for (int i = 1; i < 10; i++)
        //    {
        //        RecData.Add(new Record(code + 1, "ALFKI", i + 0, 2.3 * i, new DateTime(1991, 05, 15), "Berlin"));
        //        RecData.Add(new Record(code + 2, "ANATR", i + 2, 3.3 * i, new DateTime(1990, 04, 04), "Madrid"));
        //        RecData.Add(new Record(code + 3, "ANTON", i + 1, 4.3 * i, new DateTime(1957, 11, 30), "Cholchester"));
        //        RecData.Add(new Record(code + 4, "BLONP", i + 3, 5.3 * i, new DateTime(1930, 10, 22), "Marseille"));
        //        RecData.Add(new Record(code + 5, "BOLID", i + 4, 6.3 * i, new DateTime(1953, 02, 18), "Tsawassen"));
        //        code += 5;
        //    }
        //}
        //public List<object> EmployeeID
        //{
        //    get
        //    {
        //        var employeeID = RecData.Select(s => s.EmployeeID).Distinct().ToList();
        //        var EmployeeID = new List<object>();
        //        foreach (var id in employeeID)
        //        {
        //            EmployeeID.Add(new { value = id, text = id });
        //        }
        //        return EmployeeID;
        //    }
        //}

        //public ActionResult DataSource([FromBody]DataManager dm)
        //{
        //    IEnumerable data = RecData;

            

        //    new Syncfusion.EJ2.EJ2(null, HttpContext).



        //        ;   
                
        //    DataOperations operation = new DataOperations();
        //    if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
        //    {
        //        data = operation.PerformSorting(data, dm.Sorted);
        //    }
        //    if (dm.Where != null && dm.Where.Count > 0) //Filtering
        //    {
        //        data = operation.PerformWhereFilter(data, dm.Where, dm.Where[0].Operator);
        //    }
        //    int count = data.Cast<Record>().Count();
        //    if (dm.Skip != 0)
        //    {
        //        data = operation.PerformSkip(data, dm.Skip);
        //    }
        //    if (dm.Take != 0)
        //    {
        //        data = operation.PerformTake(data, dm.Take);
        //    }
        //    return Json(new { result = data, count = count });

        //}
































        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
