using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Permissions.DAL;



namespace Permissions.Controllers
{

    public class WorkController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        private readonly Repository _repository;



        public WorkController(IAuthorizationService authorizationService, Repository repository)
        {
            _authorizationService = authorizationService;
            _repository = repository;
        }



        public IActionResult FirstPage()
        {
            return View();
        }



        public IActionResult SecondPage()
        {
            return View();
        }



        public IActionResult ThirdPage()
        {
            return View();
        }

    }

}