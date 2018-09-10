using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm, string returnUrl = null)
        {
            //TODO: проверка пароля, загрузка пользователя из БД, и т.д. и т.п.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Fake User"),
                new Claim("age", "25", ClaimValueTypes.Integer)
            };

            var identity = new ClaimsIdentity("MyCookieMiddlewareInstance");
            identity.AddClaims(claims);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.Authentication.SignInAsync("MyCookieMiddlewareInstance",
                                                         principal,
                                                         new AuthenticationProperties
                                                         {
                                                             ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                                                         });

            _logger.LogInformation(4, "User logged in.");

            return RedirectToLocal(returnUrl);
        }













        public IActionResult Index()
        {
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
}
