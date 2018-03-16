using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;
using RazorPages.Repositories;
using Newtonsoft;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public List<Record> Records { get; private set; }

        public void OnGet()
        {
            Records = Repository.Records;
        }

        //public IActionResult UrlDatasource([FromBody]Data dm)
        //{
        //    if (order.Count() == 0)
        //        BindDataSource();
        //    var DataSource = order.ToList();
        //    int count = order.Count();
        //    var result = new DataResult
        //    {
        //        result = DataSource.Skip(dm.skip).Take(dm.take).ToList(),
        //        count = count
        //    };
        //    return dm.requiresCounts ? Json(new { result = Data.Skip(dm.skip).Take(dm.take), count = count }) : Json(Data);
        //}

        //public class DataResult
        //{
        //    public List<EditableOrder> result { get; set; }
        //    public int count { get; set; }
        //}

        //public ActionResult CrudUpdate([FromBody]EditableOrder value, string action)
        //{
        //    if (action == "update")
        //    {
        //        //Update record in database
        //    }
        //    else if (action == "insert")
        //    {
        //        //Insert record in database
        //    }
        //    else
        //    {
        //        //Delete record in database
        //    }
        //}
    }
}
