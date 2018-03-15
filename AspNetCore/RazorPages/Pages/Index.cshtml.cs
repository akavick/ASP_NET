using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Classes;
using RazorPages.Repositories;
using Syncfusion.EJ2.Grids;

namespace RazorPages.Pages
{
    public class AnotherModer : PageModel
    {
        public int Id { get; set; }
    }




    public class IndexModel : PageModel
    {
        public List<Record> Records { get; private set; }


        public void OnGet()
        {
            Records = Repository.Records;
        }
    }
}
