using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Permissions.Configuration;


namespace Permissions.Controllers
{

    public class HomeController : Controller
    {
        private readonly Config _config;

        public HomeController(IOptions<Config> config)
        {
            _config = config.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

    }

}
