using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Permissions.Configuration;



namespace Permissions.Controllers
{

    public class HomeController : Controller
    {
        private readonly SystemObjectsNames _systemObjectsNames;



        public HomeController(IOptions<SystemObjectsNames> systemObjectsNames)
        {
            _systemObjectsNames = systemObjectsNames.Value;
        }



        public IActionResult Index()
        {
            return View();
        }

    }

}
