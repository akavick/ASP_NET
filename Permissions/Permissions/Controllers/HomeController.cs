using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Permissions.Authorization.Filters;



namespace Permissions.Controllers
{



    public class HomeController : Controller
    {
        [ComponentAccessAuthorizationFilter(20011001, 1)]
        public IActionResult Index()
        {
            return View();
        }

    }



}
